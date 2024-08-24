using IKProje.Application.ViewModels.Roles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleQueries.RolesGetAllForAssign
{
    public class RoleGetAllForAssignQuery:IRequest<List<AssignRoleToUserViewModel>>
    {
        public string UserId { get; set; }
    }
}
