using IKProje.Application.ViewModels;
using IKProje.Application.ViewModels.Personel;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate
{
    public class PermissionCreateCommand:IRequest<PermissionCreateCommandResponse>
    {
  
        //public string Name { get; set; } = default!;
        public DateTime? DateofReply { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
       
        public string TypeofPermissionId { get; set; }
       
               
        public string? UserName { get; set; }

       


    }
}
