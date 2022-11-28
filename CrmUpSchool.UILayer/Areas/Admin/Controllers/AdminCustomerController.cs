using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Admin
{
    [Area("Admin")]
    [AllowAnonymous]

    public class AdminCustomerController : Controller
    {
        ICustomerService _customerService;

        public AdminCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerListt()
        {
            var JsonCustomer = JsonConvert.SerializeObject(_customerService.TGetList());
            return Json(JsonCustomer);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.TInsert(customer);
            var values = JsonConvert.SerializeObject(customer);
            return Json(values);
        }

        public IActionResult GetById(int CustomerID) 
        {
            var values = _customerService.TGetByID(CustomerID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }




    }
}
