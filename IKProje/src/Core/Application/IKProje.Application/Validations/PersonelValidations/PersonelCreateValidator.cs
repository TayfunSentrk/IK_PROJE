using FluentValidation;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.PersonelValidations
{
    public class PersonelCreateValidator:AbstractValidator<PersonelCreateCommand>
    {
        public PersonelCreateValidator()
        {
            BaseValidationRules.FirstName<PersonelCreateCommand>(RuleFor(x => x.FirstName));
            BaseValidationRules.LastName<PersonelCreateCommand>(RuleFor(x => x.LastName));
            BaseValidationRules.IdentityNumber<PersonelCreateCommand>(RuleFor(x => x.TCIdentityNumber));
            BaseValidationRules.BirthDate<PersonelCreateCommand>(RuleFor(x => x.BirthDate));
            BaseValidationRules.Address<PersonelCreateCommand>(RuleFor(x => x.Address));
            BaseValidationRules.PlaceBirth<PersonelCreateCommand>(RuleFor(x => x.PlaceOfBirth));
            BaseValidationRules.Salary<PersonelCreateCommand>(RuleFor(x => x.Salary));
            //RuleFor(z => z.Password).NotNull().NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            //RuleFor(z => z.PasswordConfirm).NotNull().NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(x => x.Gender).NotNull().NotEmpty().WithMessage("Cinsiyet alanı boş bırakılamaz.");
        }
       

    }
}
