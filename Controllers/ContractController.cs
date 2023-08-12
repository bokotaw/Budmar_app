using Budmar_app.Services.Contracts;
using Budmar_app.ViewModels.ContractViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budmar_app.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        // GET: ContractController
        public async Task<ActionResult> Index()
        {
            var contracts = await _contractService.GetAllContracts();
            return View(contracts);
        }

        // GET: ContractController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //ContractViewModel contractViewModel = await _contractService.GetContractById(id);

            ContractDetalisViewModel contractViewModel = await _contractService.GetContractDetalis(id);

            if(contractViewModel==null)
                return RedirectToAction(nameof(Index));
            else
                return View(contractViewModel);
        }

        // GET: ContractController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContractViewModel contractViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _contractService.CreateContract(contractViewModel);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ContractController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ContractViewModel contractViewModel = await _contractService.GetContractById(id);
            if(contractViewModel==null)
                return RedirectToAction(nameof(Index));
            else
                return View(contractViewModel);
        }

        // POST: ContractController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContractViewModel contractViewModel)
        {
            if (ModelState.IsValid)
            {
                await _contractService.UpdateContract(contractViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Details), contractViewModel);
        }

        // GET: ContractController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: ContractController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
