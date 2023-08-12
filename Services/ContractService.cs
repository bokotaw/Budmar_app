using AutoMapper;
using Budmar_app.Models;
using Budmar_app.Repository.Contracts;
using Budmar_app.Services.Contracts;
using Budmar_app.ViewModels.ContractViewModels;
using Budmar_app.ViewModels.EmployeeViewModels;
using Budmar_app.ViewModels.WorkHourViewModels;

namespace Budmar_app.Services
{
    public class ContractService : IContractService
    {
        private readonly IRepository<Contract> _repository;
        private readonly IContractRepository _contractRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<ContractService> _logger;

        public ContractService(
            IRepository<Contract> repository, 
            IContractRepository contractRepository,
            IEmployeeService employeeService,
            IMapper mapper, 
            ILogger<ContractService> logger)
        {
            _repository = repository;
            _contractRepository = contractRepository;
            _employeeService = employeeService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Contract> CreateContract(ContractViewModel contractViewModel)
        {
            try
            {
                if(contractViewModel == null)
                    throw new ArgumentNullException(nameof(contractViewModel));

                Contract contract = _mapper.Map<Contract>(contractViewModel);
                return await _repository.CreateAsync(contract);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while adding contract: {contractViewModel}", contractViewModel);
                throw;
            }
        }

        public async Task DeleteContract(ContractViewModel contractViewModel)
        {
            try
            {
                if (contractViewModel != null)
                {
                    Contract contract = await _repository.GetAsync(contractViewModel.Id);
                    if(contract != null)
                    {
                        _ = _repository.DeleteAsync(contract);
                        await _repository.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ContractViewModel>> GetAllContracts()
        {
            try
            {
                IEnumerable<Contract> contracts = await _repository.GetAllAsync();
                IEnumerable<ContractViewModel> contractViewModels = _mapper.Map<IEnumerable<ContractViewModel>>(contracts);
                return contractViewModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while getting the contracts");
                throw;
            }
        }

        public async Task<ContractViewModel> GetContractById(int id)
        {
            try
            {
                Contract contract = await _repository.GetAsync(id);
                ContractViewModel contractViewModel = _mapper.Map<ContractViewModel>(contract);
                return contractViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while getting contract with ID: {id}", id);
                throw;
            }
        }

        public async Task<Contract> UpdateContract(ContractViewModel contractViewModel)
        {
            try
            {
                if (contractViewModel != null)
                {
                    Contract contract = _mapper.Map<Contract>(contractViewModel);
                    await _repository.UpdateAsync(contract);
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while update contract: {contractViewModel}", contractViewModel);
                throw;
            }
        }

        public async Task<ContractDetalisViewModel> GetContractDetalis(int contractId)
        {
            var contract = await _contractRepository.GetContractDetalis(contractId);

            var contractDetalisVM = new ContractDetalisViewModel
            {
                Id = contract.Id,
                Title = contract.Title,
                Description = contract.Description,
                Address = contract.Address,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate
            };

            if(contract.WorkHours != null)
            {
                
                contractDetalisVM.WorkHours = contract.WorkHours.Select(wh => new WorkHourViewModel
                {
                    Id = wh.Id,
                    EmployeeId = wh.EmployeeId,
                    StartTime = wh.StartTime,
                    EndTime = wh.EndTime,
                    ContractId = contract.Id,
                    ContractTitle = wh.Contract?.Title,
                    SalarySupplement = wh.SalarySupplement,
                    DailySalary = wh.DailySalary,
                    BaseHourlyWage = wh.BaseHourlyWage,
                }).ToList();

                foreach (var item in contractDetalisVM.WorkHours)
                {
                    item.Employee = await _employeeService.GetEmployeeById(item.EmployeeId);
                }
            }

            return contractDetalisVM;

        }
    }
}
