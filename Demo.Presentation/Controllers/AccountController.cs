using Demo.DataAccess.Models.IdentiyModel;
using Demo.Presentation.ViewModels.AccountViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Demo.Presentation.Controllers
{


    public class AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager) : Controller
    {
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerView)
        {
            if (!ModelState.IsValid) return View(registerView);

            var User = new ApplicationUser()
            {
                UserName = registerView.UserName,
                Email = registerView.Email,
                FirstName = registerView.FirstName,
                LastName = registerView.LastName,
            };

            var Result = _userManager.CreateAsync(User, registerView.Password).Result;

            if (Result.Succeeded)
                RedirectToAction("Login");
            else
            {
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerView);

        }

        [HttpGet]
        public IActionResult LogIn() => View();


        [HttpPost]

        public IActionResult LogIn(LoginViewModel loginView)
        {
            if (ModelState.IsValid) return BadRequest();

            var user = _userManager.FindByEmailAsync(loginView.Email).Result;

            if (user is not null)
            {

                var flag = _userManager.CheckPasswordAsync(user, loginView.Password).Result;

                if (flag) {
                    var Result = _signInManager.PasswordSignInAsync(user, loginView.Password, loginView.RememberMe, false).Result;

                    if (Result.IsNotAllowed)
                        ModelState.AddModelError(string.Empty, "Your Account Isnot Confirmed Yet ");
                     
                    
                    if (Result.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "Your Account Locked !");


                    if (!Result.Succeeded) 
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                
            }




            ModelState.AddModelError(string.Empty, "Invalid Login Attempet ");
            return View(loginView);
        }

    }
}
