using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingle
{
    public class ExpensesGetSingleQuery: IRequest<ExpensesViewModel>
    {
        public string Id { get; set; }

        public bool IsApproval { get; set; } = false;
    }
}
