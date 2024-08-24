using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit
{
    public class AdvanceEditCommandResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public AdvanceEditCommand Response { get; set; }
    }
}
