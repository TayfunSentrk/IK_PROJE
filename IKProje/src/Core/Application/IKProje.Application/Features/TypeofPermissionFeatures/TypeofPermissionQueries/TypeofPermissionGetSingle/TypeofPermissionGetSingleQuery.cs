using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetSingle
{
    public class TypeofPermissionGetSingleQuery:IRequest<TypeofPermissionViewModel>
    {
        public string Id { get; set; }
    }
}
