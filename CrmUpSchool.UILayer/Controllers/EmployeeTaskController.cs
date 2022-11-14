﻿using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    public class EmployeeTaskController : Controller
    {
        private readonly IEmployeeTaskService _employeeTaskService;
        private readonly UserManager<AppUser> _userManager;

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService, UserManager<AppUser> userManager)
        {
            _employeeTaskService = employeeTaskService;
            _userManager = userManager;
        }

      
  
        public IActionResult Index()
        {
            var values = _employeeTaskService.TGEtEmployeeTaskByemployee();
            return View(values);
        }

        [HttpGet]
        public  IActionResult AddTask()
        {
            List<SelectListItem> userValues = (from x in _userManager.Users.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name + " " + x.Surname,
                                                   Value = x.Id.ToString()
                                               }).ToList();

            ViewBag.v = userValues;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddTaskAsync(EmployeeTask employeeTask)
        {
            employeeTask.Status = "Gorev Atandı";
            employeeTask.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
     
            var values = await _userManager.FindByNameAsync(User.Identity.Name);          
            employeeTask.AtamaYapanKullanici = values.Name + " " + values.Surname;

            _employeeTaskService.TInsert(employeeTask);
            return RedirectToAction("Index");

            
        }
    }
}
