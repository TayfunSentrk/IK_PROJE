using IKProje.Application.ViewModels.PermissionViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetAll
{
    public class PermissionGetAllQuery : IRequest<IEnumerable<PermissionViewModel>>
    {

        public string UserName { get; set; }
        public bool Tracking { get; set; } = true;
        public bool IsApproval { get; set; } = false;
        
    }
}
