using IKProje.Domain.Entities.Base;
using IKProje.Domain.Entities.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Entity
{
    public class TypeofPermission:BaseEntity
    {
        public TypeofPermission()
        {
            Permissions = new HashSet<Permission>();
        }
        public byte Duration { get; set; }
        public Gender Gender { get; set; }
        public ICollection< Permission> Permissions { get; set; }

    }
}
