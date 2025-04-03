using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOS;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModels.EmployeeEnums;
using Demo.DataAccess.Models.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeSerivces employeeSerivces, ILogger<EmployeeController> _logger, IWebHostEnvironment _environment) : Controller
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



        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = employeeSerivces.GetEmployeeById(id.Value);

            return emp is null ? NotFound() : View(emp);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = employeeSerivces.GetEmployeeById(id.Value);

            if (emp is null) return NotFound();

            var employeeDto = new UpdateEmployeeDto()
            {
                Address = emp.Address,
                Email = emp.Email,
                Id = emp.Id,
                IsActive = emp.IsActive,
                EmployeeType = Enum.Parse<EmployeeTypes>(emp.EmployeeType),
                Age = (int)emp.Age,
                Gender = Enum.Parse<Gender>(emp.Gender),
                HiringDate = emp.HiringDate,
                Name = emp.Name,
                PhoneNumber = emp.PhoneNumber,
                Salary = emp.Salary




            };
            return View(emp);


        }

        [HttpPost]
        public IActionResult Edit(int? id, UpdateEmployeeDto updateEmployee)
        {
            if (!id.HasValue || id != updateEmployee.Id) return BadRequest();


            if (!ModelState.IsValid) return View(updateEmployee);

            try
            {
                var Result = employeeSerivces.UpdateEmployee(updateEmployee);
                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not Found :)");
                    return View(updateEmployee);
                }

            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(updateEmployee);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }





            }


        }

    }
}
