using FluentValidation;
using IKProje.Application.Features.RoleFeatures.RoleCommands.RoleCreate;
using IKProje.Application.Features.RoleFeatures.RoleCommands.RoleEdit;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.RoleValidations
{
    public class RoleEditValidator:AbstractValidator<UpdateRoleViewModel>
    {
        public RoleEditValidator()
        {
            BaseValidationRules.NameRules<UpdateRoleViewModel>(RuleFor(x => x.Name));
        }
    }
}
