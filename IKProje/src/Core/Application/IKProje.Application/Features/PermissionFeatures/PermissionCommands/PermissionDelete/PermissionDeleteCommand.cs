using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionDelete
{
    public class PermissionDeleteCommand:IRequest<PermissionDeleteCommandResponse>
    {
        public string Id { get; set; }
    }
}
