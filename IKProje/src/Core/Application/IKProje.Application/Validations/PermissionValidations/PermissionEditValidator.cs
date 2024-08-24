using FluentValidation;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.PermissionValidations
{
    public class PermissionEditValidator:AbstractValidator<PermissionEditCommand>
    {
        public PermissionEditValidator()
        {
            //BaseValidationRules.NameRules<PermissionEditCommand>(RuleFor(x => x.Name));
            //BaseValidationRules.DayCount<PermissionEditCommand>(RuleFor(x => x.DayCount));
            //BaseValidationRules.FinishedDay<PermissionEditCommand>(RuleFor(x => x.FinishedDate));
            BaseValidationRules.StartedDay<PermissionEditCommand>(RuleFor(x => x.StartedDate));
       
        }
    }
}
