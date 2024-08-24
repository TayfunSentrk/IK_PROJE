using IKProje.Application.ViewModels.Personel;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit
{
    public class PermissionEditCommand:IRequest<PermissionEditCommandResponse>
    {
        public string Id { get; set; } 
      
        public DateTime StartedDate { get; set; }
                
        public string TypeofPermissionId { get; set; }
     
    }
}
