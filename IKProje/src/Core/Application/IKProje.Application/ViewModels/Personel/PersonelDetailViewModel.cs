using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.ViewModels.Personel
{
    public class PersonelDetailViewModel
    {
        public string FirstName { get; set; } = default!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = default!;
        public string? SecondLastName { get; set; }
        public string TCIdentityNumber { get; set; } = default!;
        public DateTime StartDateOfWork { get; set; } = DateTime.Now;
        public DateTime BirthDate { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PlaceOfBirth { get; set; } = default!;
        public string? PicturePath { get; set; }
        public string? DepartmanId { get; set; }
        public string? VocationId { get; set; }
        public string? CompanyId { get; set; }


        //Navigation properties

        public virtual Department? Department { get; set; }//departman Entity
        public virtual Vocation? Vocation { get; set; } //Meslek Entity
        public virtual Company? Company { get; set; } //Şirket Entity
    }
}
