using IKProje.Domain.Entities.Base.Enums;
using IKProje.Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Configuration
{
    public class PersonelConfiguration /*: IEntityTypeConfiguration<Personel>*/
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.HasQueryFilter(e => e.IsActive == true);
            builder.HasKey(x => x.Id);
            builder.Property(p => p.FirstName).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.LastName).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.TCIdentityNumber).IsRequired().HasColumnType("nchar(11)");
            builder.Property(p => p.BirthDate).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.Address).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(p => p.PlaceOfBirth).IsRequired().HasColumnType("nvarchar(50)");

            DepartmentConfiguration departmentConfiguration = new DepartmentConfiguration();
            CompanyConfiguration companyConfiguration = new CompanyConfiguration();
            VocationConfiguration vocationConfiguration = new VocationConfiguration();
           
            builder.HasData(new Personel()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin.admin",
                Email = "aydemir.ozdemir@bilgeadamboost.com",
                TCIdentityNumber="34918241307",
                PhoneNumber = "5555555555",
                Salary=13400,
                Gender=Gender.Erkek,
                Address= "Bursa Bursa Bursa",
                BirthDate =new DateTime(1994,11,13),
                PlaceOfBirth= "Bursa Bursa",
                Department = departmentConfiguration.DepartmentSend(),
                DepartmanId = departmentConfiguration.DepartmentSend().Id,
                Company=companyConfiguration.CompanySend(),
                CompanyId=companyConfiguration.CompanySend().Id,
                Vocation=vocationConfiguration.VocationSend(),
                VocationId=vocationConfiguration.VocationSend().Id,
                PasswordHash= HashPassword("Password12*")




        });


        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }



    }
}



