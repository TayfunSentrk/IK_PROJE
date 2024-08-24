using FluentValidation;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesEdit;
using IKProje.Application.Validations.BaseValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.ExpensesValidations
{
    public class ExpensesEditValidator:AbstractValidator<ExpensesEditCommand>
    {
        public ExpensesEditValidator()
        {
            //BaseValidationRules.NameRules<ExpensesEditCommand>(RuleFor(x => x.Name));
            BaseValidationRules.TotalAmount<ExpensesEditCommand>(RuleFor(x => x.TotalAmount));
            BaseValidationRules.Currency<ExpensesEditCommand>(RuleFor(x => x.Currency));
            BaseValidationRules.TypeofExpenses<ExpensesEditCommand>(RuleFor(x => x.TypeofExpenses));
        }
    }
}
