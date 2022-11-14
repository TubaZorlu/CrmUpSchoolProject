using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Models
{
    public class RoleVM
    {
        [Required(ErrorMessage ="Lütfen boş geçmeyeniz")]
        public string RoleName { get; set; }
    }
}
