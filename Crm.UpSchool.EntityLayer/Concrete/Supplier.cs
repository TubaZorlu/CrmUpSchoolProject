using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.EntityLayer.Concrete
{
    public class Supplier
    {
        [Key]
        public int SuppilerID { get; set; }
        public string SuppilerCompanyName { get; set; }
        public string SuppilerCity { get; set; }
        public string SuppilerPhone { get; set; }
        public string SuppilerMail { get; set; }
        public string SuppilerContactName { get; set; }

    }
}
