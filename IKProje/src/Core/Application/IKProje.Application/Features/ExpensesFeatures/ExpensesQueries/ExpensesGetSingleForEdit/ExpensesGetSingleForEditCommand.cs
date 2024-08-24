using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingleForEdit
{
    public class ExpensesGetSingleForEditCommand:IRequest<ExpensesViewForEdit>
    {

        public string Id { get; set; }

        public bool IsTracking { get; set; } = true;
    }
}
