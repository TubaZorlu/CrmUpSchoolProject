using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Models
{
    //Özeleştirilmiş doğrulama
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description =$"Şifre ne az {length} karakter olmalıdır"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Şifre ne az 1 tane küçük karakter içermelidir"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Şifre ne az 1 tane büyük karakter içermelidir"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Şifre ne az 1 tane alfanümerik olmayan karakter içermelidir"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Şifre ne az 1 tane sayı içermelidir"
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"İlgili mail adresi {email} zaten sisstemde mevcut ,farklı bir maill adresi ile kayıt olun"
            };
        }


        public override IdentityError DuplicateUserName(string username)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"İlgili kullanıcı adı {username} zaten sistemde mevcut, farklı bir kullanıcı adı  ile kayıt olun"
            };
        }


    }
}
