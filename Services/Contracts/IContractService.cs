using Budmar_app.Models;
using Budmar_app.ViewModels.ContractViewModels;
using Budmar_app.ViewModels.EmployeeViewModels;

namespace Budmar_app.Services.Contracts
{
    public interface IContractService
    {
        public Task<Contract> CreateContract(ContractViewModel contractViewModel);
        public Task<Contract> UpdateContract(ContractViewModel contractViewModel);
        public Task DeleteContract(ContractViewModel contractViewModel);
        public Task<ContractViewModel> GetContractById(int id);
        public Task<IEnumerable<ContractViewModel>> GetAllContracts();


        public Task<ContractDetalisViewModel> GetContractDetalis(int id);
    }
}
