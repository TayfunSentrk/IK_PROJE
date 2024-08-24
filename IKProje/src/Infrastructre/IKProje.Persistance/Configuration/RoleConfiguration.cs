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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new List<Role>()
           {
               new Role()
               {
                   Id="Admin",
                   Name="Admin",

               },
               new Role() {
                   Id="Yönetici",
                   Name="Yönetici"
               }
           });
        }
    }
}
