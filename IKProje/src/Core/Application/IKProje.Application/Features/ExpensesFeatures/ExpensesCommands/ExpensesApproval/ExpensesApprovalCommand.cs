using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesApproval
{
    public class ExpensesApprovalCommand:IRequest<ExpensesApprovalCommandResponse>
    {
        public string Id { get; set; }
        
        public Approval StatusofApproval { get; set; }
    }
}
