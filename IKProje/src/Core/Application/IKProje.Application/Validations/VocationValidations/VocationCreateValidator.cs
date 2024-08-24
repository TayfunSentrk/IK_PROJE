using FluentValidation;
using IKProje.Application.Features.VocationFeatures.VocationCommands.VocationCrreate;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.VocationValidations
{
    public class VocationCreateValidator:AbstractValidator<VocationCreateCommand>
    {
        public VocationCreateValidator()
        {
            BaseValidationRules.NameRules<VocationCreateCommand>(RuleFor(x=>x.Name));
        }
    }
}
