using IKProje.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Configuration
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity ,new()
    {
        public  virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasQueryFilter(e => EF.Property<bool>(e, "IsActive") );
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
