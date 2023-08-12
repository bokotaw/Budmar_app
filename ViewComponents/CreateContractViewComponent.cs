using Budmar_app.ViewModels.ContractViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Budmar_app.ViewComponents
{
    public class CreateContractViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Views/Shared/Partials/_CreateContract.cshtml", new ContractViewModel());
        }
    }
}
