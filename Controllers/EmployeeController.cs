using Budmar_app.Services.Contracts;
using Budmar_app.ViewComponents;
using Budmar_app.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budmar_app.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            EmployeeViewModel employeeViewModel = await _employeeService.GetEmployeeById(id);
            if(employeeViewModel == null)
                return RedirectToAction(nameof(Index));
            else
                return View(employeeViewModel);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(employeeViewModel.HourlyWageString))
                    {
                        ModelState.AddModelError(string.Empty, "Błędna wartość stawki godzinowej");
                    }
                    else
                    {
                        employeeViewModel.HourlyWage = decimal.Parse(employeeViewModel.HourlyWageString);
                        await _employeeService.CreateEmployee(employeeViewModel);
                    }                   
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occured while creating employee: {employeeViewModel}", employeeViewModel);
                    ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas dodawania nowego pracownika");
                    return View(employeeViewModel);
                    throw;
                }
                TempData["SuccessMessage"] = $"Pracownik {employeeViewModel.FirstName + employeeViewModel.LastName} został dodany";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Wystąpił błąd podczas dodawnia pracownika. Spróbuj ponownie!";
            return RedirectToAction(nameof(Index));

        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            EmployeeViewModel employeeViewModel = await _employeeService.GetEmployeeById(id);
            if (employeeViewModel == null)
                return RedirectToAction(nameof(Index));
            else
                return View(employeeViewModel);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                employeeViewModel.HourlyWage = decimal.Parse(employeeViewModel.HourlyWageString);
                await _employeeService.UpdateEmployee(employeeViewModel);
                return RedirectToAction(nameof(Index));
            }
                
            return View(nameof(Details), employeeViewModel);

            
            
        }

        // GET: EmployeeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            EmployeeViewModel employeeViewModel = await _employeeService.GetEmployeeById(id);
            if (employeeViewModel != null)
            {
                await _employeeService.DeleteEmployee(employeeViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: EmployeeController/Delete/5
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
