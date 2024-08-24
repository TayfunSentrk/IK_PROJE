using FluentValidation;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.CompanyValidations
{
    public class CompanyEditValidator:AbstractValidator<CompanyEditCommand>
    {
        public CompanyEditValidator()
        {
            BaseValidationRules.NameRules<CompanyEditCommand>(RuleFor(x => x.Name));
        }
    }
}
