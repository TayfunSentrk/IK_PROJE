using FluentValidation;
using IKProje.Application.Features.VocationFeatures.VocationCommands.VocationCrreate;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.VocationValidations
{
    public class VocationViewModelValidator:AbstractValidator<VocationViewModel>
    {
        public VocationViewModelValidator()
        {
            BaseValidationRules.NameRules<VocationViewModel>(RuleFor(x => x.Name));
        }
    }
}
