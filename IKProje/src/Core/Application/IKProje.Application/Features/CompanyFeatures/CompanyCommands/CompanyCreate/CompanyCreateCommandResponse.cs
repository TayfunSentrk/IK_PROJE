using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate
{
    public class CompanyCreateCommandResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public CompanyCreateCommand Response { get; set; }

    }
}
