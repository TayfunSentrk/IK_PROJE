using IKProje.Application.ViewModels;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate
{
    public class ExpensesCreateCommand : IRequest<ExpensesCreateCommandResponse>
    {

        public decimal TotalAmount { get; set; }
        public Currency Currency { get; set; }
        public TypeofExpenses TypeofExpenses { get; set; }
        public string Documantation { get; set; }
        public string? UserName { get; set; }
        public string? CompanyId { get; set; } //++
        public CompanyViewModel? CompanyViewModel { get; set; }
    }
}
