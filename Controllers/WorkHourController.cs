using Budmar_app.Services.Contracts;
using Budmar_app.ViewModels.WorkHourViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budmar_app.Controllers
{
    public class WorkHourController : Controller
    {
        private readonly IWorkHourService _workHourService;

        public WorkHourController(IWorkHourService workHourService)
        {
            _workHourService = workHourService;
        }

        // GET: WorkHourController
        public async Task<ActionResult> Index()
        {
            var workHours = await _workHourService.GetAllWorkHours();
            return View(workHours);
        }

        // GET: WorkHourController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkHourController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkHourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(WorkHourViewModel workHourViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _workHourService.CreateWorkHour(workHourViewModel);

                    int contractId = (int)workHourViewModel.ContractId;

                    return RedirectToAction(nameof(Details), "Contract", new { id = contractId});
                }
                catch (Exception)
                {

                    throw;
                }
               
            }
            return RedirectToAction(nameof(Index), "Contract", new {id = workHourViewModel.Id});
        }

        // GET: WorkHourController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkHourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: WorkHourController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkHourController/Delete/5
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
