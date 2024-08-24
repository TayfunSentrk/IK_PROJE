using IKProje.Domain.Entities.Base.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Entity
{
    public class Personel:IdentityUser
    {
        public Personel()
        {
            Advances=new HashSet<Advance>();
            Expenses=new HashSet<Expenses>();
            Permissions=new HashSet<Permission>();
        }
        public string FirstName { get; set; } = default!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = default!;
        public string? SecondLastName { get; set; }
        public string TCIdentityNumber { get; set; } = default!;
        public DateTime StartDateOfWork { get; set; }= DateTime.Now;
        public DateTime? FinishDateOfWork { get; set; }
        public DateTime BirthDate { get; set; } = default!;
        public decimal Salary { get; set; } 
        public string Address { get; set; } = default!;
        public Gender Gender { get; set; } 
        public string PlaceOfBirth { get; set; } = default!;
        public bool  IsActive { get; set; } = true;
        public string? PicturePath { get; set; }
        public string VocationId { get; set; } = default!;
        public string CompanyId { get; set; } = default!;
        public string DepartmanId { get; set; } = default!;
        public decimal? UsedAdvance {  get; set; } 
        public int? NumberofAdvance {  get; set; }
        public DateTime? AdvanceRenewalDate {  get; set; }





        //Navigation properties

        public virtual Department? Department { get; set; }//departman Entity
        public virtual Vocation? Vocation { get; set; } //Meslek Entity
        public virtual Company? Company { get; set; } //Şirket Entity
        public virtual ICollection<Advance> Advances { get; set; } //Şirket Entity
        public virtual ICollection<Expenses> Expenses { get; set; } //Şirket Entity
        public virtual ICollection<Permission> Permissions { get; set; } //Şirket Entity
    }
}
