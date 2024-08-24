using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionApproval
{
    public class PermissionApprovalCommand:IRequest<PermissionApprovalCommandResponse>
    {
        public string Id { get; set; }
        public Approval StatusofApproval { get; set; }
    }
}
