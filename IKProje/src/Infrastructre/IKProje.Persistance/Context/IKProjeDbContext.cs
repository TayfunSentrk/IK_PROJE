using IKProje.Domain.Entities.Base;
using IKProje.Domain.Entities.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Context
{
    public class IKProjeDbContext:IdentityDbContext<Personel,Role,string>
    {
        //Dbcontext içerisinde base in ihtiyacı olan option ı veriyorum.
        public IKProjeDbContext(DbContextOptions<IKProjeDbContext> options):base(options) { }
       

        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Role> Roller { get; set; }
        public DbSet<Department> Departmanlar { get; set; }
        public DbSet<Vocation> Meslekler { get; set; }
        public DbSet<Company> Sirketler { get; set; }
        public DbSet<Permission> Izinler { get; set; }
        public DbSet<Expenses> Harcamalar { get; set; }
        public DbSet<Advance> Avanslar { get; set; }
        public DbSet<TypeofPermission> IzınTurleri { get; set; }
        public DbSet<DepartmentCompany> DepartmanŞirketler { get; set; }



       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //var datas = ChangeTracker.Entries<BaseEntity>();
            //foreach (var entity in datas)
            //{
            //    _ = entity.State switch
            //    {
            //        EntityState.Added => entity.Entity.CreatedTime = DateTime.Now,
            //        EntityState.Modified => entity.Entity.LastUpdatedTime = DateTime.Now,
            //    };
            //}
            return base.SaveChangesAsync(cancellationToken);
        }



    }
}
