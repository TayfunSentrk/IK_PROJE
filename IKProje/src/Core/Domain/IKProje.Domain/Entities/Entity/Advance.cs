using IKProje.Domain.Entities.Base;
using IKProje.Domain.Entities.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Entity
{
    public class Advance:BaseForBusiness
    {
        public decimal TotalAmount { get; set; }
        public Currency Currency { get; set; }
        public TypeofAdvance TypeofAdvance { get; set; }
        public string Description { get; set; }
        public string PersonelId { get; set; }
        public Personel Personel { get; set; }
        public Company? Company { get; set; }
        public string? CompanyId { get; set; }


     
    }
}
