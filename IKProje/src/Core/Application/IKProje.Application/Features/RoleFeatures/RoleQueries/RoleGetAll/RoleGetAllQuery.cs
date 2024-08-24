using IKProje.Application.ViewModels.Roles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleQueries.RoleGetAll
{
    public class RoleGetAllQuery:IRequest<IEnumerable<RoleViewModel>>
    {
    }
}
