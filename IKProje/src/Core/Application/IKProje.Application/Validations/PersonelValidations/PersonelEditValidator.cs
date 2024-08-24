using FluentValidation;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelEdit;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels.Personel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.PersonelValidations
{
    public class PersonelEditValidator:AbstractValidator<PersonelInformationForEdit>
    {
        public PersonelEditValidator()
        {
            BaseValidationRules.Address<PersonelInformationForEdit>(RuleFor(x => x.Address));
            RuleFor(x=>x.PhoneNumber).NotNull().NotEmpty().WithMessage("Bu alan boş geçilemez.");
        }
    }
}
