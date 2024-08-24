using FluentValidation;
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
    public class DepartmentViewModelValidator:AbstractValidator<DepartmentViewModel>
    {
        public DepartmentViewModelValidator()
        {
            BaseValidationRules.NameRules<DepartmentViewModel>(RuleFor(x => x.Name));
        }
    }
}
