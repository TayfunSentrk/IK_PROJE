using IKProje.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Entity
{
    public class Permission:BaseForBusiness
    {
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public byte DayCount { get; set; }
        public string TypeofPermissionId { get; set; }
        public string PersonelId { get; set; }

        //NavigationPropertiy
        public TypeofPermission TypeofPermission { get; set; }
        public Personel Personel { get; set; }
        public Company? Company { get; set; }
        public string? CompanyId { get; set; }



    }
}
