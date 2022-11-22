using Crm.UpSchool.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous]
    public class AnnouncmentController : Controller
    {
        
        private readonly IAnnouncmentService _announcmentService;

        public AnnouncmentController(IAnnouncmentService announcmentService)
        {
            _announcmentService = announcmentService;
        }

        public IActionResult Index()
        {
            var values = _announcmentService.TGetList();
            return View(values);
        }
    }
}
