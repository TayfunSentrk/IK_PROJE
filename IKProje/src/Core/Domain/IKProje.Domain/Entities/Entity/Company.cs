using IKProje.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Domain.Entities.Entity
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Personeller = new HashSet<Personel>();
            Departmanlar=new HashSet<DepartmentCompany>();
            Avanslar=new HashSet<Advance>();
            Harcamalar=new HashSet<Expenses>();
            Izinler=new HashSet<Permission>();
        }

        public string Unvan { get; set; }
        public string MersisNo { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string? LogoPath { get; set; }
        public string Phone { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public int CalisanSayisi { get; set; }
        public DateTime KurulusTarihi { get; set; }
        public DateTime SozlesmeBaslangic { get; set; }
        public DateTime SozlesmeBitis { get; set; }





        //navigation properties
        public ICollection<Personel>? Personeller { get; set; }
        public ICollection<DepartmentCompany>? Departmanlar {  get; set; }
        public ICollection<Advance>? Avanslar {  get; set; }
        public ICollection<Expenses>? Harcamalar {  get; set; }
        public ICollection<Permission>? Izinler {  get; set; }
    }
}
