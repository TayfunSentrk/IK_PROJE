using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit
{
    public class CompanyEditCommandResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public CompanyEditCommand Response { get; set; }
    }
}
