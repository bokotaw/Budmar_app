using Budmar_app.Data;
using Budmar_app.Models;
using Microsoft.EntityFrameworkCore;

namespace Budmar_app.Repository.Contracts
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
			try
			{
				var employee = await _context.Employees
                    .Include(e => e.WorkHours)
                    .ThenInclude(w => w.Contract)
                    .FirstOrDefaultAsync(e => e.Id == employeeId);

                return employee;
                
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
