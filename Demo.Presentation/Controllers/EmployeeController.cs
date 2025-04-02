using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOS;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeSerivces employeeSerivces,ILogger<EmployeeController> _logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var employees = employeeSerivces.GetAllEmployees(); 
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
             
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmploeeDto emploeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = employeeSerivces.CreateEmoplyee(emploeeDto);

                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }

            return View(emploeeDto);

        }
    }
}
