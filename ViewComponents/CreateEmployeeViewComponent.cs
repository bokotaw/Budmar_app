using Budmar_app.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Budmar_app.ViewComponents
{
    public class CreateEmployeeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Views/Shared/Partials/_CreateEmployee.cshtml", new EmployeeViewModel());
        }
    }
}
