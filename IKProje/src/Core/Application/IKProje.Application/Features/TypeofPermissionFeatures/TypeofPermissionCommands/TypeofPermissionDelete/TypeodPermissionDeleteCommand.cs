using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionDelete
{
    public class TypeofPermissionDeleteCommand:IRequest<TypeofPermissionDeleteCommandResponse>
    {
        public string Id { get; set; }
    }
}
