using IKProje.Domain.Entities.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Base
{
    public abstract class BaseForBusiness:BaseEntity
    {
      
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
     
        public DateTime DateofReply {  get; set; }
        public Approval StatusofApproval { get; set; } = Approval.AwaitingApproval;
    }
}
