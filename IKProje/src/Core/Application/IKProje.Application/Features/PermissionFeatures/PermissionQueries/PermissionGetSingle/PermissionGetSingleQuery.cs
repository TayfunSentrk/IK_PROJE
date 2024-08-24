using IKProje.Application.ViewModels.PermissionViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingle
{
    public class PermissionGetSingleQuery: IRequest<PermissionViewModel>
    {
        public string Id { get; set; }

        public bool IsApproval { get; set; } = false;
    }
}
