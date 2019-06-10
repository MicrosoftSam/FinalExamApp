using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExamApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExamApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMngr,
            SignInManager<IdentityUser> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public ViewResult Index()
        {
            var users = userManager.Users.ToList();

            return View(users);
        }

        [AllowAnonymous]
        public ViewResult LogIn(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                    await userManager.FindByNameAsync(loginModel.Name);
                if(user != null)
                {
                    await signInManager.SignOutAsync();
                    if((await signInManager.PasswordSignInAsync(user,
                        loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }    
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUser(string name)
        {
            IdentityUser user =
                await userManager.FindByNameAsync(name);
            if(user != null)
            {
                return View(user);
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            IdentityUser user =
                await userManager.FindByIdAsync(id);
            if(user != null)
            {
                await userManager.DeleteAsync(user);
            }

            return RedirectToAction("Index");
        }
    }
}