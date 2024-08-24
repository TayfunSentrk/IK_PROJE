using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetAll
{
    public class TypeofPermissionGetAllQuery:IRequest<IEnumerable<TypeofPermissionViewModel>>
    {
        public bool Tracking { get; set; } = true;
        public string UserName { get; set; } 
    }
}
