using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionEdit
{
    public class TypeofPermissionEditCommand:IRequest<TypeofPermissionEditCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; } = default!;
        public byte Duration { get; set; }
        public Gender Gender { get; set; }
    }
}
