using IKProje.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Entity
{
    public class Vocation:BaseEntity
    {
        public Vocation()
        {
            Personeller = new HashSet<Personel>();
        }
        //navigation properties
        public ICollection<Personel>? Personeller { get; set; }
    }
}
