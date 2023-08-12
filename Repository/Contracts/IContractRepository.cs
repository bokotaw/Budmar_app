using Budmar_app.Models;

namespace Budmar_app.Repository.Contracts
{
    public interface IContractRepository
    {
        public Task<Contract> GetContractDetalis(int contractId);
    }
}
