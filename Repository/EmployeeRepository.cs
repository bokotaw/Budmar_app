using Budmar_app.Data;
using Budmar_app.Models;
using Budmar_app.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Budmar_app.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeDetalis(int employeeId)
        {
            var employee = _context.Employees
                .Include(e => e.WorkHours)
                .ThenInclude(wh => wh.Contract)
                .FirstOrDefault(e => e.Id == employeeId);

            return employee;
        }
    }
}
