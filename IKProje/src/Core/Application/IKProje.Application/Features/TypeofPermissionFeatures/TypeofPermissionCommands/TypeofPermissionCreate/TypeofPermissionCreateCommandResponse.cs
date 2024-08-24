using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionCreate
{
    public class TypeofPermissionCreateCommandResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public TypeofPermissionCreateCommand Response { get; set; }
    }
}
