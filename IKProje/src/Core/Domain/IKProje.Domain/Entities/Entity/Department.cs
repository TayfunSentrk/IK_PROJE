using IKProje.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Entity
{
    public class Department: BaseEntity
    {
        public Department()
        {
            Personeller = new HashSet<Personel>();
            Şiketler=new HashSet<DepartmentCompany>();
        }
        //navigation properties
        public ICollection<Personel>? Personeller { get; set; }
        public ICollection<DepartmentCompany>? Şiketler { get; set; }
    }
}
