using Budmar_app.Services.Contracts;
using Budmar_app.ViewModels.WorkHourViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Budmar_app.ViewComponents
{
    public class CreateWorkHourViewComponent : ViewComponent
    {
        private readonly IEmployeeService _employeeService;
        private readonly IContractService _contractService;

        public CreateWorkHourViewComponent(IEmployeeService employeeService, IContractService contractService)
        {
            _employeeService = employeeService;
            _contractService = contractService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int contractId)
        {
           
            var contract = await _contractService.GetContractById(contractId);
            ViewBag.Employees = await _employeeService.GetAllEmployees();

            return View("~/Views/Shared/Partials/_CreateWorkHour.cshtml", new WorkHourViewModel{ ContractId = contract.Id, ContractTitle = contract.Title});
        }
    }
}
