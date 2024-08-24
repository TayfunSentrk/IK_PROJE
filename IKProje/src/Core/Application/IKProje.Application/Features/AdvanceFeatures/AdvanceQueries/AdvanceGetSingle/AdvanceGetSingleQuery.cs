using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingle
{
    public class AdvanceGetSingleQuery: IRequest<AdvanceViewModel>
    {
        public string Id { get; set; }

        public bool IsApproval { get; set; }
    }
}
