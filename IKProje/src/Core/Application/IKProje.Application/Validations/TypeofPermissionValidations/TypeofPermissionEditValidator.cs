using FluentValidation;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionCreate;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionEdit;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.TypeofPermissionValidations
{
    public class TypeofPermissionEditValidator:AbstractValidator<TypeofPermissionEditCommand>
    {
        public TypeofPermissionEditValidator()
        {
            BaseValidationRules.DayCount<TypeofPermissionEditCommand>(RuleFor(x => x.Duration));
            BaseValidationRules.NameRules<TypeofPermissionEditCommand>(RuleFor(x => x.Name));
            RuleFor(x => x.Gender).NotNull().NotEmpty().WithMessage("Cinsiyet alanı boş bırakılamaz.");
        }
    }
}
