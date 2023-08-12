using Budmar_app.Data;
using Budmar_app.Models;
using Budmar_app.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Budmar_app.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly AppDbContext _context;

        public ContractRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Contract> GetContractDetalis(int contractId)
        {
            var contractDetalis = _context.Contracts
                .Include(c => c.WorkHours)
                .FirstOrDefault(c => c.Id == contractId);

            return contractDetalis;
        }
    }
}
