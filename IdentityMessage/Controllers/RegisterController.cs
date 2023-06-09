﻿using EntityLayer;
using IdentityMessage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityMessage.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpModel p)
        {
                AppUser user = new AppUser()
                {
                    Email=p.Mail,
                    Name = p.Name,
                    Surname = p.Surname,
                    Gender = p.Gender,
                    UserName = p.UserName,
                };
                if(p.Password==p.ConfirmPassword)
                {
                    var result=await _userManager.CreateAsync(user,p.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                }
            return View();
        }
    }
}
