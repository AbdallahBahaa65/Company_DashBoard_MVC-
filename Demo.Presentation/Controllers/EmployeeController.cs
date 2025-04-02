using Demo.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeSerivces employeeSerivces) : Controller
    {
        public IActionResult Index()
        {
            var employees = employeeSerivces.GetAllEmployees(); 
            return View(employees);
        }
    }
}
