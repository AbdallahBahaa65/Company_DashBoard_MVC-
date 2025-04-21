using Demo.DataAccess.Models.IdentiyModel;
using Demo.Presentation.Utilities;
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
                RedirectToAction("LogIn");
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
            if (!ModelState.IsValid) return View(loginView);

            var user = _userManager.FindByEmailAsync(loginView.Email).Result;

            if (user is not null)
            {

                var flag = _userManager.CheckPasswordAsync(user, loginView.Password).Result;

                if (flag)
                {
                    var Result = _signInManager.PasswordSignInAsync(user, loginView.Password, loginView.RememberMe, false).Result;
                    if (Result.IsNotAllowed)
                        ModelState.AddModelError(string.Empty, "Your Account Isnot Confirmed Yet ");
                    if (Result.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "Your Account Locked !");
                    if (Result.Succeeded)
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                }

            }
            else
                ModelState.AddModelError(string.Empty,"Invalid Login"); 
            return View(loginView);
        }


        [HttpGet]
        public new IActionResult SignOut()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction(nameof(LogIn));
        }



        [HttpGet]
        public IActionResult ForgetPassword() => View();

        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var User = _userManager.FindByEmailAsync(forgetPasswordViewModel.Email).Result;
                if (User is not null)
                {

                    var token = _userManager.GeneratePasswordResetTokenAsync(User).Result;

                    var URL = Url.Action("ResetPassword", "Account", new { email = forgetPasswordViewModel.Email, token }, Request.Scheme);


                    //Send Email 
                    var email = new Email()
                    {

                        To = User.Email,
                        Subject = "Reset Password ",
                        Body = URL
                    };

                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));


                }

            }
            ModelState.AddModelError(string.Empty, "Invalid Operation ");
            return View(nameof(ForgetPassword), forgetPasswordViewModel);
        }




        public IActionResult CheckYourInbox() => View();

        public IActionResult ResetPassword(string email, string Token)
        {
            TempData["email"] = email;
            TempData["token"] = Token;
            return View();
        }


        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid) return View();


            string email = TempData["email"] as string ?? string.Empty; 
            string token = TempData["token"] as string ?? string.Empty; 
            var User = _userManager.FindByEmailAsync(email).Result;

            if (User is not null)
            {
              var Result =  _userManager.ResetPasswordAsync(User, token, resetPasswordViewModel.NewPassword).Result;

                if (Result.Succeeded)
                    return RedirectToAction(nameof(LogIn));
                else
                {
                    foreach (var error in Result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            } 
            return View(nameof(ResetPassword),resetPasswordViewModel);
        }
    }
}

