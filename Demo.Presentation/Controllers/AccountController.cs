using Demo.DataAccess.Models.IdentiyModel;
using Demo.Presentation.ViewModels.AccountViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{

   
    public class AccountController(UserManager<ApplicationUser> _userManager) : Controller
    {
      public IActionResult Register()=> View();

        [HttpPost]
         public IActionResult Register(RegisterViewModel registerView)
        {
            if(!ModelState.IsValid) return View(registerView);

            var User = new ApplicationUser()
            {
                UserName = registerView.UserName,
                Email = registerView.Email,
                FirstName = registerView.FirstName,
                LastName = registerView.LastName,
            };

           var Result= _userManager.CreateAsync(User,registerView.Password).Result;

            if(Result.Succeeded) 
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

    }
}
