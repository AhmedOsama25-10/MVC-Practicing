using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mobi__Shop.Models;
using Mobi_Shop.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly UserManager<IdentityUser> UserManager;

        public RoleController(RoleManager<IdentityRole> _RoleManager, UserManager<IdentityUser> _userManager )
        {
            RoleManager = _RoleManager;
            UserManager = _userManager;
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid==true)
            {
                IdentityRole role = new()
                {
                    Name = roleViewModel.RoleName
                };
                IdentityResult result = await RoleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    };
                }
            }
            return View(roleViewModel);

        }
        public IActionResult AssigningRoleToUser()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AssigningRoleToUser(AssigningUserToRoleByUserName assigningUserToRoleByUserName)
        {
            if (ModelState.IsValid==true)
            {
               IdentityUser user = await UserManager.FindByNameAsync(assigningUserToRoleByUserName.UserName);
                if (user !=null && assigningUserToRoleByUserName.RoleName!= null)
                {
                   IdentityResult result =  await UserManager.AddToRoleAsync(user, assigningUserToRoleByUserName.RoleName);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                }
                return BadRequest("user not found");
            }
            return View(assigningUserToRoleByUserName);

        }


    }
}
