using FluentValidation;
using IKProje.Application.Features.VocationFeatures.VocationCommands.VocationEdit;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.VocationValidations
{
    public class VocationEditValidator:AbstractValidator<VocationEditCommand>
    {
        public VocationEditValidator()
        {
            BaseValidationRules.NameRules<VocationEditCommand>(RuleFor(x => x.Name));
        }
    }
}
