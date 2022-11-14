using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.EntityLayer.Concrete
{
    public class EmployeeTask
    {
        public int EmployeeTaskID { get; set; }
        public string EmployeeTaskTitle { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string AtamaYapanKullanici { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<EmployeeTaskDetails> EmployeeTaskDetails { get; set; }


    }
}
