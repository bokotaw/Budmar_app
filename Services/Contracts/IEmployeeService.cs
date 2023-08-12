using Budmar_app.Models;
using Budmar_app.ViewModels.EmployeeViewModels;

namespace Budmar_app.Services.Contracts
{
    public interface IEmployeeService
    {
        public Task<Employee> CreateEmployee(EmployeeViewModel EmployeeViewModel);
        public Task UpdateEmployee(EmployeeViewModel employeeViewModel);
        public Task DeleteEmployee(EmployeeViewModel employeeViewModel);
        public Task<EmployeeViewModel> GetEmployeeById(int id);
        public Task<IEnumerable<EmployeeViewModel>> GetAllEmployees();
    }
}
