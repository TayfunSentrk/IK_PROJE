using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.ExpensesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesApproval
{
    public class ExpensesApprovalCommandResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public ExpensesViewModel? Response { get; set; }
       
    }
}
