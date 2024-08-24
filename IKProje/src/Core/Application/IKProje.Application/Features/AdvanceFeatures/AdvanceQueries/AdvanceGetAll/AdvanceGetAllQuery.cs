using IKProje.Application.ViewModels.AdvanceViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetAll
{
    public class AdvanceGetAllQuery : IRequest<IEnumerable<AdvanceViewModel>>
    {
        public bool Tracking { get; set; } = true;

        public bool IsApproval { get; set; } = false;
        public string UserName { get; set; }
    }
}
