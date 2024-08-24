using FluentValidation;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelSignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.PersonelValidations
{
    public class PersonelSigInValidator:AbstractValidator<PersonelSigInCommand>
    {
        public PersonelSigInValidator()
        {
            RuleFor(z => z.Email).EmailAddress().WithMessage("Email Formatına uygun giriş yapınız.").NotNull().NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(z => z.Password).NotNull().NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
        }
    }
}
