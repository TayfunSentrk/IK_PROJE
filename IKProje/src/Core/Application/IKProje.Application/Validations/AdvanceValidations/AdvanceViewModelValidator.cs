using FluentValidation;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels.AdvanceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.AdvanceValidations
{
    public class AdvanceViewModelValidator:AbstractValidator<AdvanceViewModel>
    {
        public AdvanceViewModelValidator()
        {
            BaseValidationRules.NameRules<AdvanceViewModel>(RuleFor(x => x.Name));
            BaseValidationRules.TotalAmount<AdvanceViewModel>(RuleFor(x => x.TotalAmount));
            BaseValidationRules.Currency<AdvanceViewModel>(RuleFor(x => x.Currency));
            BaseValidationRules.TypeofAdvance<AdvanceViewModel>(RuleFor(x => x.TypeofAdvance));
            BaseValidationRules.Description<AdvanceViewModel>(RuleFor(x => x.Description));
     
        }
    }
}
