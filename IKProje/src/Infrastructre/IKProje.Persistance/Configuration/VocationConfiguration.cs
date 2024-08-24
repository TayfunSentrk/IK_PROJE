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
    public class VocationConfiguration : BaseConfiguration<Vocation>, IEntityTypeConfiguration<Vocation>
    {
        public override void Configure(EntityTypeBuilder<Vocation> builder)
        {
            builder.HasMany(x => x.Personeller).WithOne(x => x.Vocation).HasForeignKey(x => x.VocationId);
            builder.HasData(vocation, new Vocation
            {

                Id = Guid.NewGuid().ToString(),
                Name = "Satiş Müdürü"
            });

            base.Configure(builder);
        }


        public static Vocation vocation = new Vocation()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Developer",
        };

        public Vocation VocationSend()
        {
            return vocation;
        }
    }
}
