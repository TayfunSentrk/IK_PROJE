using IKProje.Application.ViewModels.Personel;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Base.Enums;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.ViewModels.PermissionViewModels
{
    public class PermissionViewModel
    {
        public string Id { get; set; } 
        public string Name { get; set; } = default!;
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        public DateTime DateofReply { get; set; }
        public Approval StatusofApproval { get; set; } = Approval.AwaitingApproval;
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public byte DayCount { get; set; }
        public string TypeofPermissionId { get; set; }
        public string PersonelId { get; set; }
        public string CompanyId { get; set; } //++
        public CompanyViewModel CompanyViewModel { get; set; }

        //NavigationPropertiy

        public TypeofPermission TypeofPermission { get; set; }

        public  Domain.Entities.Entity.Personel Personel { get; set; }
        public TypeofPermissionViewModel TypeofPermissionViewModel { get; set; }
       public PersonelViewModel PersonelViewModel { get; set; }
    }
}
