using FluentValidation;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentCreate;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentEdit;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.DepartmentValidations
{
    public class DepartmentEditValidator:AbstractValidator<DepartmentEditCommand>
    {
        public DepartmentEditValidator()
        {
            BaseValidationRules.NameRules<DepartmentEditCommand>(RuleFor(x => x.Name));
        }
    }
}
