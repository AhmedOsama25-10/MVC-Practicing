using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mobi_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi_Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManger;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManger , SignInManager<IdentityUser> _signInManager)
        {
            userManger = _userManger;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid==true)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = registerViewModel.UserName;
                user.Email = registerViewModel.Email;
                user.PhoneNumber = registerViewModel.Phone;
                IdentityResult result = await userManger.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                   await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(registerViewModel);
                }

            }
            return View();
        }
        public IActionResult Login(string ReturnUrl = "~/Home/Index")
        {
            ViewBag.RedirectionUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string ReturnUrl = "~/Home/Index")
        {
            if (ModelState.IsValid==true)
            {

                IdentityUser user = await userManger.FindByNameAsync(loginViewModel.UserName);
                if (user !=null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.KeepMeLogin, false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect user name or password");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name");
                }
                

            }
            return View(loginViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
