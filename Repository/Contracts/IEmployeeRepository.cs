using Budmar_app.Models;

namespace Budmar_app.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        public Task<Employee> GetEmployeeDetalis(int employeeId);
    }
}
