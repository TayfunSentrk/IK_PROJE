using IKProje.Domain.Entities.Base;
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
    public class BaseForBusinessConfiguration<T>:BaseConfiguration<T>,IEntityTypeConfiguration<T>where T : BaseEntity,new()
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            
            base.Configure(builder);
        }
    }
}
