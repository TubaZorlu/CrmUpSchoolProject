using Crm.UpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous]
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
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                int number = rnd.Next(100000, 999999);
                AppUser appUser = new AppUser();

                appUser.UserName = p.UserName;
                appUser.Name = p.Name;
                appUser.Surname = p.Surname;
                appUser.Email = p.Email;
                appUser.PhoneNumber = p.PhoneNumber;
                appUser.Code = number.ToString();


                
        

                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);
                    if (result.Succeeded)
                    {
                        SendEmail(appUser.Code);
                        return RedirectToAction("EmailConfirmed", "Register");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }

                else
                {
                    ModelState.AddModelError("", "şifreler uyuşmuyor");
                }
            }


            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirmed() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailConfirmed(AppUser appUser)
        {
            var user = await _userManager.FindByEmailAsync(appUser.Email);
            if (user.Code==appUser.Code)
            {
                user.EmailConfirmed = true;

                var result = _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public void SendEmail(string emailcode)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "tubatastan24@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", "tubatastan24@gmail.com");
            mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

            mimeMessage.Subject = "Üyelik Kaydı"; //Gönderilecek mailin başlığı

            SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("tubatastan24@gmail.com", "pzvymftacjovndys");//bu kodu senin alman lazım
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);



        }

       


    }
}
