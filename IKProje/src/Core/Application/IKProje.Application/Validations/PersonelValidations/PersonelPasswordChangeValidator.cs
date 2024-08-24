using FluentValidation;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelPasswordChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.PersonelValidations
{
    public class PersonelPasswordChangeValidator:AbstractValidator<PersonelPasswordChangeCommand>
    {
        public PersonelPasswordChangeValidator()
        {
            RuleFor(z => z.PasswordNew).NotNull().NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(z => z.PasswordOld).NotNull().NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(z => z.PasswordConfirm).NotNull().NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
        }
        
    }
}
