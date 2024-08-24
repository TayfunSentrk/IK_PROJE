using FluentValidation;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.PermissionValidations
{
    public class PermissionCreateValidator:AbstractValidator<PermissionCreateCommand>
    {
        public PermissionCreateValidator()
        {
            //BaseValidationRules.NameRules<PermissionCreateCommand>(RuleFor(x => x.Name));
            //BaseValidationRules.DayCount<PermissionCreateCommand>(RuleFor(x => x.DayCount));
            BaseValidationRules.FinishedDay<PermissionCreateCommand>(RuleFor(x => x.FinishedDate));
            BaseValidationRules.StartedDay<PermissionCreateCommand>(RuleFor(x => x.StartedDate));
        
        }
    }
}
