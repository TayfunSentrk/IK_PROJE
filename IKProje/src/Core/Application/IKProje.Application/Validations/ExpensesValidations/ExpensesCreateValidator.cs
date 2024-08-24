using FluentValidation;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.ExpensesValidations
{
    public class ExpensesCreateValidator:AbstractValidator<ExpensesCreateCommand>
    {
        public ExpensesCreateValidator()
        {
            //BaseValidationRules.NameRules<ExpensesCreateCommand>(RuleFor(x => x.Name));
            BaseValidationRules.TotalAmount<ExpensesCreateCommand>(RuleFor(x => x.TotalAmount));
            BaseValidationRules.Currency<ExpensesCreateCommand>(RuleFor(x => x.Currency));
            BaseValidationRules.TypeofExpenses<ExpensesCreateCommand>(RuleFor(x => x.TypeofExpenses));
          //dokumantasyon ekleyelim
        }
    }
}
