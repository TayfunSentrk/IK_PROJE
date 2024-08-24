using FluentValidation;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.CompanyValidations
{
    public class CompanyViewModelValidator:AbstractValidator<CompanyViewModel>
    {
        public CompanyViewModelValidator()
        {
           
            BaseValidationRules.NameRules<CompanyViewModel>(RuleFor(x => x.Name));
        }
    }
}
