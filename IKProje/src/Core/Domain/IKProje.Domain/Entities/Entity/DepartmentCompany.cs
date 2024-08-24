using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Entity
{
    public class DepartmentCompany
    {
        public int Id { get; set; }
        public string DepartmanId { get; set; }
        public string CompanyId { get; set; }

        //navigation properties
        public virtual Department? Department { get; set; }//departman Entity
        public virtual Company? Company { get; set; } //Şirket Entity
    }
}
