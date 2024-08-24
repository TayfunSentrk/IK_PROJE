using FluentValidation;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Domain.Entities.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.AdvanceValidations
{
    public class AdvanceCreateValidator:AbstractValidator<AdvanceCreateCommand>
    {
        public AdvanceCreateValidator()
        {
  
            //BaseValidationRules.NameRules<AdvanceCreateCommand>(RuleFor(x => x.Name));
            BaseValidationRules.TotalAmount<AdvanceCreateCommand>(RuleFor(x => x.TotalAmount));
            BaseValidationRules.Currency<AdvanceCreateCommand>(RuleFor(x => x.Currency));
            BaseValidationRules.TypeofAdvance<AdvanceCreateCommand>(RuleFor(x => x.TypeofAdvance));
            BaseValidationRules.Description<AdvanceCreateCommand>(RuleFor(x => x.Description));

        }

      
       
    }
}
