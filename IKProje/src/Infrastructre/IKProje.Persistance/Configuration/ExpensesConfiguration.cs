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
    public class ExpensesConfiguration:BaseForBusinessConfiguration<Expenses>
    {
        public override void Configure(EntityTypeBuilder<Expenses> builder)
        {
            builder.HasOne(x=>x.Personel).WithMany(x => x.Expenses).HasForeignKey(x => x.PersonelId);
            builder.HasOne(x=>x.Company).WithMany(x => x.Harcamalar).HasForeignKey(x => x.CompanyId);
            builder.Property(x => x.Currency).IsRequired();
            builder.Property(x => x.TypeofExpenses).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
            base.Configure(builder);
        }
    }
}
