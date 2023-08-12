using Budmar_app.Models;
using Budmar_app.Services;
using Budmar_app.Services.Contracts;
using Budmar_app.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Budmar_app.ViewComponents
{
    public class EditEmployeeViewComponent : ViewComponent
    {
        private readonly IEmployeeService _employeeService;
        public EditEmployeeViewComponent(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int employeeId)
        {
            EmployeeViewModel employeeViewModel = await _employeeService.GetEmployeeById(employeeId);

            if (employeeViewModel == null)
                return View("~/Views/Employee/Index.cshtml");

            return View("~/Views/Shared/Partials/_EditEmployee.cshtml", employeeViewModel);
        }
    }
}
