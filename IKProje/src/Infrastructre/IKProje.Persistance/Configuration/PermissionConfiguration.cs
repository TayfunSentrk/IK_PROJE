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
    public class PermissionConfiguration:BaseForBusinessConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(x => x.DayCount).IsRequired().HasColumnType("tinyint");
            builder.Property(x => x.StartedDate).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.FinishedDate).IsRequired().HasColumnType("datetime");
            builder.HasOne(x => x.Personel).WithMany(x => x.Permissions).HasForeignKey(x=>x.PersonelId);
            builder.HasOne(x => x.TypeofPermission).WithMany(x => x.Permissions).HasForeignKey(x=>x.TypeofPermissionId);
            builder.HasOne(x => x.Company).WithMany(x => x.Izinler).HasForeignKey(x=>x.CompanyId);

            base.Configure(builder);
        }
    }
}
