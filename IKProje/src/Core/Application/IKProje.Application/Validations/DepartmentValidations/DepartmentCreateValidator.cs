using FluentValidation;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentCreate;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.DepartmentValidations
{
    public class DepartmentCreateValidator:AbstractValidator<DepartmentCreateCommand>
    {
        public DepartmentCreateValidator()
        {
            BaseValidationRules.NameRules<DepartmentCreateCommand>(RuleFor(x => x.Name));
        }
    }
}
