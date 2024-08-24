using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionCreate
{
    public class TypeofPermissionCreateCommand:IRequest<TypeofPermissionCreateCommandResponse>
    {
     
        public string Name { get; set; } 
        public byte Duration { get; set; }
        public Gender Gender { get; set; }
    }
}
