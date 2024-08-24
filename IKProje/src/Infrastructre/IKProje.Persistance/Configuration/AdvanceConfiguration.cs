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
    public class AdvanceConfiguration:BaseForBusinessConfiguration<Advance>
    {
        public override void Configure(EntityTypeBuilder<Advance> builder)
        {
            builder.HasOne(x => x.Personel).WithMany(x=>x.Advances).HasForeignKey(x=>x.PersonelId);
            builder.HasOne(x => x.Company).WithMany(x=>x.Avanslar).HasForeignKey(x=>x.CompanyId);
            builder.Property(x => x.Currency).IsRequired();
            builder.Property(x => x.TypeofAdvance).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
           
            base.Configure(builder);
        }
    }
}
