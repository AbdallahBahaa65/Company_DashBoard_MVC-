using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOS;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.Presentation.ViewModels.DepartmentViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{

    [Authorize]
    public class DepartmentController(IDepartmentService departmentService, IWebHostEnvironment _environment, ILogger<DepartmentController> _logger) : Controller
    {
        public IActionResult Index()
        {
            //ViewData["Message"] = "Hallo From View Data";
            //ViewBag.Message= "Hallo From View Data";


            //ViewBag.Message = new DepartmentDto()
            //{
            //    Name = "Test View Bag "
            //};

            //ViewData["Message"] = new DepartmentDto()
            //{
            //    Name = "Test View Data "
            //};




            var department = departmentService.GetAll();

            return View(department);

        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public IActionResult Create(DepartmentEditeViewModel departmentEditeView)
        {



            if (ModelState.IsValid)
            {
                try
                {
                    var departmentDto = new CreateDepartmentDto()
                    {
                        Code = departmentEditeView.Code,
                        Description = departmentEditeView.Description,
                        Name = departmentEditeView.Name,
                        DateOfCreation = departmentEditeView.DateOfCreation

                    };
                    int Result = departmentService.AddDepartment(departmentDto);
                    string Message;
                    if (Result > 0)
                        Message = $"Department {departmentDto.Name} Created Successfully ";
                    else 
                        Message = $"Department {departmentDto.Name}  Not Created  ";


                    TempData["Message"]=Message;
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

            return View(departmentEditeView);
        }



        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var department = departmentService.GetDetails(id.Value);

            if (department is null) return NotFound();

            return View(department);

        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var Result = departmentService.GetDetails(id.Value);

            if (Result is null) return NotFound();

            var departmenViewModel = new DepartmentEditeViewModel()
            {

                Code = Result.Code,
                Name = Result.Name,
                Description = Result.Description,
                DateOfCreation = Result.CreatedOn

            };

            return View(departmenViewModel);


        }

        //[HttpPost]
        //public IActionResult Edit([FromRoute] int? id, DepartmentEditeViewModel viewModel)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {

        //            var updateDepartment = new UpdateDepartmentDto()
        //            {
        //                Id = id.Value,
        //                Code = viewModel.Code,
        //                Name = viewModel.Name,
        //                Description = viewModel?.Description ?? " ",
        //                DateOfCreation = viewModel.DateOfCreate
        //            };

        //            var Result = departmentService.UpdateDepartment(updateDepartment);

        //            if (Result > 0) return RedirectToAction(nameof(Index));
        //            else ModelState.AddModelError(string.Empty, "Department Not Updated !!!!!!!!!!!!!!!!!!!!!!");








        //        }
        //        catch (Exception ex)
        //        {
        //            if (_environment.IsDevelopment())
        //            {
        //                ModelState.AddModelError(string.Empty, ex.Message);

        //            }
        //            else
        //            {
        //                _logger.LogError(ex.Message);
        //                return View("ErrorView", ex.Message);
        //            }
        //        }
        //    }
        //    return View(viewModel);
        //}


        //public IActionResult Delete([FromRoute] int? id)
        //{

        //    if (!id.HasValue) return BadRequest();
        //    var department = departmentService.GetDetails(id.Value);
        //    if (department is null) return NotFound();

        //    return View(department);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (id == 0) return BadRequest();

            try
            {

                bool flag = departmentService.DeleteDepartment(id);
                if (flag)
                    return RedirectToAction(nameof(Index));

                else
                {
                    ModelState.AddModelError(string.Empty, "Department Not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Delete), new { id });

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

