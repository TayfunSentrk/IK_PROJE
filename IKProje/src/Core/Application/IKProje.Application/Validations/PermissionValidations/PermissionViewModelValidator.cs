using FluentValidation;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels.PermissionViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.PermissionValidations
{
    public class PermissionViewModelValidator:AbstractValidator<PermissionViewModel>
    {
        public PermissionViewModelValidator()
        {
            BaseValidationRules.NameRules<PermissionViewModel>(RuleFor(x => x.Name));
            BaseValidationRules.DayCount<PermissionViewModel>(RuleFor(x => x.DayCount));
            BaseValidationRules.FinishedDay<PermissionViewModel>(RuleFor(x => x.FinishedDate));
            BaseValidationRules.StartedDay<PermissionViewModel>(RuleFor(x => x.StartedDate));
            BaseValidationRules.TypeofPermission<PermissionViewModel>(RuleFor(x => x.TypeofPermissionViewModel));
        }
    }
}
