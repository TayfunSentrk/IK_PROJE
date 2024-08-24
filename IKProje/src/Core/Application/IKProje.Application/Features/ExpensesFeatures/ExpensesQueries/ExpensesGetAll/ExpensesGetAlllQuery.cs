using IKProje.Application.ViewModels.ExpensesViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetAll
{
    public class ExpensesGetAlllQuery:IRequest<IEnumerable<ExpensesViewModel>>
    {
        public bool Tracking { get; set; } = true;
        public bool IsApproval { get; set; } = false;
        public string UserName { get; set; }
    }
}
