using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOS;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModels.EmployeeEnums;
using Demo.DataAccess.Models.Shared.Enums;
using Demo.Presentation.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeSerivces employeeSerivces, ILogger<EmployeeController> _logger, IWebHostEnvironment _environment,IDepartmentService departmentService ) : Controller
    {
        public IActionResult Index(string? EmployeeSearchName )
        {
            var employees = employeeSerivces.GetAllEmployees(EmployeeSearchName);
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create( )
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDto = new CreateEmploeeDto() { 
                    
                        DepartmentId = employeeViewModel.DepartmentId,
                        Address = employeeViewModel.Address,
                        Age = employeeViewModel.Age,
                        Email = employeeViewModel.Email,
                        EmployeeType = employeeViewModel.EmployeeType,
                        Gender = employeeViewModel.Gender,
                        HiringDate = employeeViewModel.HiringDate,
                        IsActive = employeeViewModel.IsActive,
                        Name = employeeViewModel.Name,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        Salary = employeeViewModel.Salary,
                        Image= employeeViewModel.Image 

                    
                    
                    };

                    int Result = employeeSerivces.CreateEmoplyee(employeeDto);

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

            return View(employeeViewModel);

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
            var employeeDto = new EmployeeViewModel()
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
                Salary = emp.Salary,
                DepartmentId = emp.DepartmentId,
                Image=emp.Image
                
            };
            return View(employeeDto);


        }

        [HttpPost]
        public IActionResult Edit(int? id, EmployeeViewModel employeeViewModel)
        {
            if (!id.HasValue ) return BadRequest();


            if (!ModelState.IsValid) return View(employeeViewModel);

            try
            {
                var employeeDto = new UpdateEmployeeDto()
                {
                    Id = id.Value,
                    Name = employeeViewModel.Name,
                    PhoneNumber = employeeViewModel.PhoneNumber,
                    DepartmentId = employeeViewModel.DepartmentId,
                    Address = employeeViewModel.Address,
                    Age = employeeViewModel.Age,
                    Email = employeeViewModel.Email,
                    IsActive = employeeViewModel.IsActive,
                    Salary = employeeViewModel.Salary,
                    EmployeeType = employeeViewModel.EmployeeType,
                    Gender = employeeViewModel.Gender,
                    HiringDate = employeeViewModel.HiringDate,
                    Image=employeeViewModel.Image
                    
                };
                var Result = employeeSerivces.UpdateEmployee(employeeDto);
                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not Found :)");
                    return View(employeeViewModel);
                }

            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeViewModel);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }





            }
        }
            [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id==0   ) return BadRequest();


           

            try
            {
                var Deleted = employeeSerivces.DeleteEmplyee(id);
                if (Deleted )
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not Deleted :)");
                    return RedirectToAction(nameof(Delete),new {id});

                }

            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("Error", ex);
                }





            }


        }

    }
}
