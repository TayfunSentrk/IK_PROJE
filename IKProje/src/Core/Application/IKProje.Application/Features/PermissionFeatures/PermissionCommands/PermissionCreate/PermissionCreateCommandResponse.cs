using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate
{
    public class PermissionCreateCommandResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public PermissionCreateCommand Response { get; set; }
    }
}
