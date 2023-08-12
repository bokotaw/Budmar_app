using AutoMapper;
using Budmar_app.Models;
using Budmar_app.Repository.Contracts;
using Budmar_app.Services.Contracts;
using Budmar_app.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Budmar_app.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(
            IRepository<Employee> repository,
            IMapper mapper,
            ILogger<EmployeeService> logger
            )
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Employee> CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if(employeeViewModel == null)
                    throw new ArgumentNullException(nameof(employeeViewModel));

                Employee employee = _mapper.Map<Employee>(employeeViewModel);
                return await _repository.CreateAsync( employee );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while adding employee: {EmployeeViewModel}", employeeViewModel);
                throw;
            }
        }

        public async Task DeleteEmployee(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (employeeViewModel != null)
                {
                    Employee employee = await _repository.GetAsync( employeeViewModel.Id );
                    if (employee != null)
                    {
                        _ = _repository.DeleteAsync(employee);
                        await _repository.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployees()
        {
            try
            {
                IEnumerable<Employee> employees = await _repository.GetAllAsync();
                IEnumerable<EmployeeViewModel> employeeViewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
                return employeeViewModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while getting the employees");
                throw;
            }
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
            try
            {
                Employee employee = await _repository.GetAsync(id);
                EmployeeViewModel employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);
                return employeeViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while getting employee with ID: {id}", id);
                throw;
            }
        }

        
        public async Task UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if(employeeViewModel != null)
                {
                    Employee employee = _mapper.Map<Employee>(employeeViewModel);
                    await _repository.UpdateAsync(employee);
                }
                //throw new ArgumentException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while update employee: {employeeViewModel}", employeeViewModel);
                throw;
            }
        }
    }
}
