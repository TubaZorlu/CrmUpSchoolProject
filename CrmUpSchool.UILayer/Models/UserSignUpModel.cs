using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Models
{
    public class UserSignUpModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen  adını giriniz")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen  Soyad giriniz")]

        public string Surname { get; set; }
       
        [Required(ErrorMessage = "Lütfen  email giriniz")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir mail giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen  telefon giriniz")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen  şifre giriniz")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen  şifre tekarar giriniz")]
        [Compare("Password",ErrorMessage = "Lütfen  şifre tekrar giriniz")]
        public string ConfirmPassword { get; set; }
    }
}
