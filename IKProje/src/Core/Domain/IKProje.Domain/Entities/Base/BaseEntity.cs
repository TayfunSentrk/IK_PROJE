using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = default!;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public DateTime? LastUpdatedTime { get; set; }

    }
}
