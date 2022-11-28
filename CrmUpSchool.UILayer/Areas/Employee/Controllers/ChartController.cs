using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        List<DepartmantSalary> departmantSalaries = new List<DepartmantSalary>();

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult DepartmantChart()
        {
            departmantSalaries.Add(new DepartmantSalary
            {
                deparmantname = "Muhasebe",
                salaryavg=10000

            });

            departmantSalaries.Add(new DepartmantSalary
            {
                deparmantname = "IT",
                salaryavg = 20000

            });
            departmantSalaries.Add(new DepartmantSalary
            {
                deparmantname = "Satıs",
                salaryavg = 12000

            });


            return Json(new { JsonList = departmantSalaries });
        }
    }
}
