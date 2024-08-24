using IKProje.Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Configuration
{
    public class TypeofPermissionConfiguration:BaseConfiguration<TypeofPermission>
    {
        public override void Configure(EntityTypeBuilder<TypeofPermission> builder)
        {
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Gender).IsRequired();

            base.Configure(builder);
        }
    }
}
