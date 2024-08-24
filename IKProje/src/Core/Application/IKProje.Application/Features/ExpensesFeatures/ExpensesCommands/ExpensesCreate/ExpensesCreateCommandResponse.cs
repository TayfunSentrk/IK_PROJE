using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate
{
    public class ExpensesCreateCommandResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public ExpensesCreateCommand Response { get; set; }
    }
}
