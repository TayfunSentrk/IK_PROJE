using IKProje.Application.ViewModels.Roles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleQueries.RoleGetForEdit
{
    public class RoleGetForEditQuery:IRequest<UpdateRoleViewModel>
    {
        public string Id { get; set; }
    }
}
