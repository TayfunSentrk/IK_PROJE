using FluentValidation;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Domain.Entities.Base.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.AdvanceValidations
{
    public class AdvanceEditValidator:AbstractValidator<AdvanceEditCommand>
    {
        public AdvanceEditValidator()
        {
           
            //BaseValidationRules.NameRules<AdvanceEditCommand>(RuleFor(x => x.Name));
            BaseValidationRules.TotalAmount<AdvanceEditCommand>(RuleFor(x => x.TotalAmount));
            BaseValidationRules.Currency<AdvanceEditCommand>(RuleFor(x => x.Currency));
            BaseValidationRules.TypeofAdvance<AdvanceEditCommand>(RuleFor(x => x.TypeofAdvance));
            BaseValidationRules.Description<AdvanceEditCommand>(RuleFor(x => x.Description));
          
         
        }



       
    }
}
