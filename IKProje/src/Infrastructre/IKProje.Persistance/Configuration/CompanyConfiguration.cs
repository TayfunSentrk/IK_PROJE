using IKProje.Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Configuration
{
    public class CompanyConfiguration :BaseConfiguration<Company>, IEntityTypeConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasMany(x => x.Departmanlar).WithOne(x => x.Company).HasForeignKey(x=>x.CompanyId);
            builder.HasMany(x => x.Personeller).WithOne(x=>x.Company).HasForeignKey(x => x.CompanyId);
            builder.HasData(company);


            base.Configure(builder);
        }
        public static Company company = new Company()
              {
                  Id = "Ulker",
                  Name = "Ulker",
                  Unvan="A.Ş",
                  MersisNo= "0920-0034-0390-0011",
                  VergiNo= "906 002 2039",
                  VergiDairesi= "Büyük Mükellefler",
                  Phone= "02165242500",
                  Adres= "Kısıklı Mahallesi, Ferah Caddesi No: 1, 34692 Büyükçamlıca-Üsküdar, İstanbul, Türkiye",
                  Mail= "ir@ulker.com.tr",
                  CalisanSayisi=51000,
                  KurulusTarihi=new DateTime(1944,2,22),
                  SozlesmeBaslangic=new DateTime(2023,12,19),
                  SozlesmeBitis=new DateTime(2023,12,30)
        };

        public Company CompanySend()
        {
            return company;
        }
    }
    }




