using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesDelete
{
    public class ExpensesDeleteCommand:IRequest<ExpensesDeleteCommandResponse>
    {
        public string Id { get; set; }
    }
}
