using Demo.DataAccess.Models.IdentiyModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class UserController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager) : Controller
    {
        public IActionResult Index(string? UserSearchName)
        {
            var users = _userManager.Users.AsQueryable(); 

            if (!string.IsNullOrEmpty(UserSearchName))
            {
                users = users.Where(u => u.UserName.Contains(UserSearchName));
            }
            return View(users.ToList());
        }




        [HttpGet]
        public IActionResult Details(string Id)
        {
            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();

            var UserDetails = _userManager.FindByIdAsync(Id).Result;
            return View(UserDetails);
        }




        [HttpGet]
        public IActionResult Update(string Id)
        {

            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();

            var UserUpadte = _userManager.FindByIdAsync(Id).Result;
            if (UserUpadte is not null)
                return View(UserUpadte);
            else
                return NotFound();
        }

   
        [HttpPost]
        public IActionResult Update(string Id,ApplicationUser applicationUser)
        {

            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();

            if (!ModelState.IsValid) return View(applicationUser);
            
            var user =  _userManager.FindByIdAsync(Id).Result;
           
            if (user is  null)
                return NotFound();


            user.FirstName = applicationUser.FirstName;
            user.LastName = applicationUser.LastName;
            user.PhoneNumber = applicationUser.PhoneNumber;

            var Result = _userManager.UpdateAsync(user).Result;

            if (Result.Succeeded)
                return RedirectToAction("Index"); 

            foreach (var error in Result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(applicationUser);
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {

            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();

            var UserDelete = _userManager.FindByIdAsync(Id).Result;
            return View(UserDelete);
        }

        [HttpPost]
        public IActionResult Delete(string Id , ApplicationUser applicationUser)
        {

            if (string.IsNullOrWhiteSpace(Id))
                return BadRequest();

            if (!ModelState.IsValid) return View(applicationUser);

            var user = _userManager.FindByIdAsync(Id).Result;
            if (user == null)
                return NotFound();


            var Result = _userManager.DeleteAsync(user).Result;

            if (Result.Succeeded)
                return RedirectToAction("Index"); 

            foreach (var error in Result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(applicationUser);
        }
    }
}
