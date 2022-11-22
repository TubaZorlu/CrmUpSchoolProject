using Crm.UpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous]
    public class ReportController : Controller
    {
        //static excell listesi

        public IActionResult ReposrtList() 
        {
            return View();
        }

        public IActionResult ExcelStatic()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");

            workSheet.Cells[1, 1].Value = "Personel ID";
            workSheet.Cells[1, 2].Value = "Personel Adı";
            workSheet.Cells[1, 3].Value = "Personel Soyadı";


            workSheet.Cells[2, 1].Value = "001";
            workSheet.Cells[2, 2].Value = "Tuba";
            workSheet.Cells[2, 3].Value = "Zorlu";

            workSheet.Cells[3, 1].Value = "002";
            workSheet.Cells[3, 2].Value = "Serap";
            workSheet.Cells[3, 3].Value = "Beran";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "personeller.xlsx");

          
        }

        List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
        public List<CustomerViewModel> CustomerList() 
        {
         
            using (var context = new Context()) 
            {
                customerViewModels = context.Customers.Select(x => new CustomerViewModel
                {
                    
                    Mail= x.CustomerMail,
                    Name=x.CustomerName,
                    Surname=x.CustomerSurname,
                    Phone=x.CustomerPhone

                }).ToList();

                return customerViewModels;

            }

          
        }

        public IActionResult DynamicExcel() 
        {

            return View();
        }
    }
}
