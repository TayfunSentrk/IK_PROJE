using FluentValidation;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesEdit;
using IKProje.Application.Validations.BaseValidations;
using IKProje.Application.ViewModels.ExpensesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.ExpensesValidations
{
    public class ExpensesViewModelValidator:AbstractValidator<ExpensesViewModel>
    {
        public ExpensesViewModelValidator()
        {
            BaseValidationRules.NameRules<ExpensesViewModel>(RuleFor(x => x.Name));
            BaseValidationRules.TotalAmount<ExpensesViewModel>(RuleFor(x => x.TotalAmount));
            BaseValidationRules.Currency<ExpensesViewModel>(RuleFor(x => x.Currency));
            BaseValidationRules.TypeofExpenses<ExpensesViewModel>(RuleFor(x => x.TypeofExpenses));
        }
    }
}
