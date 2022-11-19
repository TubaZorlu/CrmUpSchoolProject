using Crm.UpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditProfile userEditProfile = new UserEditProfile();

            userEditProfile.Name = values.Name;
            userEditProfile.Surname = values.Surname;
            userEditProfile.PhoneNumber = values.PhoneNumber;
            userEditProfile.Email = values.Email;

            return View(userEditProfile);
        }

        //1. soru : html tarafında kısıtlamalar ile backend tarafındaki kısıtlamalar arasında ne fark vardır?
        //2. soru : değişkenlerin büyük harf ile başlayan ile küçük harf ile başlayan arasındaki fark nedir. 


        [HttpPost]
        public async Task<IActionResult> Index(UserEditProfile p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image!=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var SaveLocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(SaveLocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                values.ImageURL = imageName;

            }
            values.Name = p.Name;
            values.Surname = p.Surname;
            values.Email = p.Email;
            values.PhoneNumber = p.PhoneNumber;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
            var result = await _userManager.UpdateAsync(values);

            if (result.Succeeded)
            {
                return RedirectToAction("Login","Index");
            }
            return View();


           
        }

    }
}
