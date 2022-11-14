using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;


        public MessageController(IMessageService messageService, UserManager<AppUser> userManager = null)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message m)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.SenderEmail = user.Email;
            m.SenderName = user.Name + " " + user.Surname;
            using (var context = new Context())
            {
                m.ReceiverName = context.Users.Where(x => x.Email == m.ReceiverEmail).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            }
            _messageService.TInsert(m);
            return RedirectToAction("SendMessage");



        }

        //ccvxrhibagsunsmm  -- mailşifre

        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(MailRequest p)
        {

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","tubatastan24@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",p.ReceiverEmail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = p.EmailContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = p.EmailSubject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("tubatastan24@gmail.com", "ccvxrhibagsunsmm");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }




    }
}
