using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingleForEdit
{
    public class AdvanceGetSingleForEditCommand:IRequest<AdvanceViewForEdit>
    {
        public string Id { get; set; }

        public bool IsTracking { get; set; } = true;
    }
}
