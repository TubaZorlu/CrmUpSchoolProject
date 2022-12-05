using CrmUpSchool.DTOLayer.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.ValidationRules.ContactValidation
{
    public class ContactUpdateValidator: AbstractValidator<ContactUpdateDto>
    {
        public ContactUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("lKonu Boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj Boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(6).WithMessage("Lütfen en az 6 karakter yazınız");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 larakter yazınız");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karakter yazınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 100 larakter yazınız");
        }
    }
}
