using Demo.DataAccess.Models.IdentiyModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class RoleController(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager) : Controller
    {
        public IActionResult Index(string? RoleSearchName)
        {

            var roles = _roleManager.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(RoleSearchName))
            {
                roles = roles.Where(u => u.Name.Contains(RoleSearchName));
            }
            return View(roles.ToList());
           
        }

        [HttpGet]
        public IActionResult Details(string Id)
        {
            var roleDetails = _roleManager.FindByIdAsync(Id).Result;
            return View(roleDetails);
        }



        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var deleteRole = _roleManager.FindByIdAsync(Id).Result;
            return View(deleteRole);
        }



        [HttpPost]
        public IActionResult Delete(string Id, IdentityRole _identityRole)
        {

            if (!ModelState.IsValid) return View(_identityRole);

            var role = _roleManager.FindByIdAsync(Id).Result;
            if (role is null)
                return NotFound();


            var Result = _roleManager.DeleteAsync(role).Result;

            if (Result.Succeeded)
                return RedirectToAction("Index"); 

            foreach (var error in Result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(_identityRole);
        }


        [HttpGet]
        public IActionResult Update(string Id)
        {

            var updateRole = _roleManager.FindByIdAsync(Id).Result;
            if (updateRole is not null)
                return View(updateRole);
            else
                return NotFound();
        }


        [HttpPost]
        public IActionResult Update(string Id, IdentityRole _identityRole)
        {

            if (!ModelState.IsValid) return View(_identityRole);

            var role = _roleManager.FindByIdAsync(Id).Result;
            if (role is null)
                return NotFound();


            role.Name = _identityRole.Name;

            var Result = _roleManager.UpdateAsync(role).Result;

            if (Result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in Result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(_identityRole);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole _identityRole)
        {
            if (!ModelState.IsValid) return View(_identityRole);
            else
            {
                var result = _roleManager.CreateAsync(_identityRole).Result;
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));

                else
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);   
            }
            return View(_identityRole);
        }



    }
}
