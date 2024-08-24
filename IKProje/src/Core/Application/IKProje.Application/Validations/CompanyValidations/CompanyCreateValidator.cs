using FluentValidation;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.CompanyValidations
{
    public class CompanyCreateValidator:AbstractValidator<CompanyCreateCommand>
    {
        public CompanyCreateValidator()
        {
            BaseValidationRules.NameRules<CompanyCreateCommand>(RuleFor(x => x.Name));
        }
    }
}
