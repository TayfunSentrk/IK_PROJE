using FluentValidation;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;
using IKProje.Application.Features.RoleFeatures.RoleCommands.RoleCreate;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.RoleValidations
{
    public class RoleCreateValidator:AbstractValidator<RoleCreateCommand>
    {
        public RoleCreateValidator()
        {
            BaseValidationRules.NameRules<RoleCreateCommand>(RuleFor(x => x.Name));
        }
        
    }
}
