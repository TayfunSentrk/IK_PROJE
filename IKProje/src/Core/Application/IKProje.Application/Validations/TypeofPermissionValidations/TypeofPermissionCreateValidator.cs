using FluentValidation;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionCreate;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.TypeofPermissionValidations
{
    public class TypeofPermissionCreateValidator:AbstractValidator<TypeofPermissionCreateCommand>
    {
        public TypeofPermissionCreateValidator()
        {
            BaseValidationRules.DayCount<TypeofPermissionCreateCommand>(RuleFor(x => x.Duration));
            BaseValidationRules.NameRules<TypeofPermissionCreateCommand>(RuleFor(x => x.Name));
            RuleFor(x => x.Gender).NotNull().NotEmpty().WithMessage("Cinsiyet alanı boş bırakılamaz.");
        }
    }
}
