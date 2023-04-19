//using AspNetCore;
using EntityLayer;
using IdentityMessage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IdentityMessage.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task <IActionResult> Index()
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.Name + " " + user.Surname;
            ViewBag.gender=user.Gender;
            ViewBag.mail = user.Email;
            ViewBag.image= "/images/" + user.ImageUrl;
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model=new UserEditViewModel();
            model.Name=user.Name;
            model.Surname=user.Surname;
            model.Phone=user.PhoneNumber;
            model.Email=user.Email;
            model.ImageUrl=user.ImageUrl;
            return View(model);
        }
        
        [HttpPost]
        public async Task <IActionResult> EditUser(UserEditViewModel p)
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Password == p.ConfirmPassword)
            {
                if (p.Image != null)
                {
                    var resourse = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(p.Image.FileName);
                    var imagename = Guid.NewGuid() + extension;
                    var savelocation = resourse + "/wwwroot/images/" + imagename;
                    var stream = new FileStream(savelocation, FileMode.Create);
                    await p.Image.CopyToAsync(stream);
                    user.ImageUrl = imagename;
                }
                user.Name = p.Name;
                user.Surname = p.Surname;
                user.PhoneNumber = p.Phone;
                user.Email = p.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifreler birbiri ile uyuşmuyor.");
            }
            return View();
        }
    }
}
