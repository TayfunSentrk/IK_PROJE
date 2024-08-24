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
    public class DepartmentConfiguration : BaseConfiguration<Department>, IEntityTypeConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(x => x.Şiketler).WithOne(x => x.Department).HasForeignKey(x => x.DepartmanId);
            builder.HasMany(x => x.Personeller).WithOne(x => x.Department).HasForeignKey(x => x.DepartmanId);
          
            builder.HasData(department
           , new Department
            {
                Id = "Yazılım",
                Name = "Yazılım"
            });
            base.Configure(builder);

           
        }
        public static Department department = new Department()
        {
            Id = "Ik",
            Name = "Ik",
        };

        public  Department DepartmentSend()
        {
            return department;
        }




    }
}
