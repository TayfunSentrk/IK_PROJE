using FluentValidation;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionEdit;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.TypeofPermissionValidations
{
    public class TypeofPermissionViewModelValidator:AbstractValidator<TypeofPermissionViewModel>
    {
        public TypeofPermissionViewModelValidator()
        {
            BaseValidationRules.DayCount<TypeofPermissionViewModel>(RuleFor(x => x.Duration));
            BaseValidationRules.NameRules<TypeofPermissionViewModel>(RuleFor(x => x.Name));
            RuleFor(x => x.Gender).NotNull().NotEmpty().WithMessage("Cinsiyet alanı boş bırakılamaz.");
        }
    }
}
