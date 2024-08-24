using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.ViewModels.AdvanceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval
{
    public class AdvanceApprovalCommandResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public AdvanceViewModel Response { get; set; }
    }
}
