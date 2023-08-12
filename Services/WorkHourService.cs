using AutoMapper;
using Budmar_app.Models;
using Budmar_app.Repository.Contracts;
using Budmar_app.Services.Contracts;
using Budmar_app.ViewModels.EmployeeViewModels;
using Budmar_app.ViewModels.WorkHourViewModels;

namespace Budmar_app.Services
{
    public class WorkHourService : IWorkHourService
    {
        private readonly IRepository<WorkHour> _repository;
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<WorkHourService> _logger;
        private readonly IMapper _mapper;

        public WorkHourService(IRepository<WorkHour> repository, IEmployeeService employeeService, ILogger<WorkHourService> logger, IMapper mapper)
        {
            _repository = repository;
            _employeeService = employeeService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<WorkHour> CreateWorkHour(WorkHourViewModel workHourViewModel)
        {
            try
            {
                if(workHourViewModel == null)
                    throw new ArgumentNullException(nameof(workHourViewModel));

                EmployeeViewModel employee = await _employeeService.GetEmployeeById(workHourViewModel.EmployeeId);

                TimeSpan totalWorkTime = workHourViewModel.EndTime - workHourViewModel.StartTime;
                double totalHoursWorked = totalWorkTime.TotalHours;

                decimal hourlyWage = (decimal)employee.HourlyWage;
                decimal dailySalary = 0;

                switch (workHourViewModel.SalarySupplement)
                {
                    case Enums.SalarySupplement.None:
                        dailySalary = (decimal)totalHoursWorked * hourlyWage;
                        break;
                    case Enums.SalarySupplement.DailyShift:
                        if(totalHoursWorked <= 8)
                            dailySalary = (decimal)totalHoursWorked * hourlyWage;
                        else
                        {
                            decimal baseSalary = 8 * hourlyWage;
                            decimal ovettimeSalary = ((decimal)totalHoursWorked - 8) * (hourlyWage * (decimal)1.50);
                            dailySalary = baseSalary + ovettimeSalary;
                        }
                        break;
                    case Enums.SalarySupplement.NightShift:
                        dailySalary = (hourlyWage * (decimal)1.63) * (decimal)totalHoursWorked;
                        break;
                    case Enums.SalarySupplement.WeekendBonus:
                        dailySalary = (hourlyWage * (decimal)2.00) * (decimal)totalHoursWorked;
                        break;
                    case Enums.SalarySupplement.HolidaysBonus:
                        dailySalary = (hourlyWage * (decimal)3.00) * (decimal)totalHoursWorked;
                        break;
                    default:
                        break;
                }

                WorkHour workHour = new WorkHour
                {
                    EmployeeId = workHourViewModel.EmployeeId,
                    StartTime = workHourViewModel.StartTime,
                    EndTime = workHourViewModel.EndTime,
                    SalarySupplement = workHourViewModel.SalarySupplement,
                    ContractId = (int)workHourViewModel.ContractId,
                    DailySalary = dailySalary,
                    BaseHourlyWage = (int)employee.HourlyWage
                };

                //WorkHour workHour = _mapper.Map<WorkHour>(workHourViewModel);
                return await _repository.CreateAsync(workHour);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while adding work hour: {workHourViewModel}", workHourViewModel);
                throw;
            }
        }

        public Task DeleteWorkHour(WorkHourViewModel workHourViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkHourViewModel>> GetAllWorkHours()
        {
            try
            {
                IEnumerable<WorkHour> workHours = await _repository.GetAllAsync();
                IEnumerable<WorkHourViewModel> workHourViewModels = _mapper.Map<IEnumerable<WorkHourViewModel>>(workHours);
                return workHourViewModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while getting the work hours");
                throw;
            }
        }

        public Task<WorkHourViewModel> GetWorkHourById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkHour> UpdateWorkHour(WorkHourViewModel workHourViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
