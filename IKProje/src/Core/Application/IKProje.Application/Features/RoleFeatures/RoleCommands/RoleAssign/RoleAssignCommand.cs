using IKProje.Application.ViewModels.Roles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleCommands.RoleAssign
{
    public class RoleAssignCommand:IRequest<List<AssignRoleToUserViewModel>>
    {
        public List<AssignRoleToUserViewModel> Roles { get; set; }
        public string UserId {  get; set; }
    }
}
