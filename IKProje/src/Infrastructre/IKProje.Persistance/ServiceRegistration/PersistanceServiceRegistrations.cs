using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using IKProje.Application.Contract.CompanyRepositories;
using IKProje.Persistance.Concrete.CompanyRepositories;
using IKProje.Application.Contract.DepartmentRepositories;
using IKProje.Persistance.Concrete.DepartmentRepositories;
using IKProje.Application.Contract.VocationRepositories;
using IKProje.Persistance.Concrete.VocationRepositories;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Persistance.Concrete.PermissionRepositories;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Persistance.Concrete.AdvanceRepositories;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Persistance.Concrete.ExpensesRepositories;
using IKProje.Application.Contract.TypeofPermissionRepository;
using IKProje.Persistance.Concrete.TypeofPermissionRepositories;

namespace IKProje.Persistance.ServiceRegistration
{
    public static class PersistanceServiceRegistrations
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<IKProjeDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            });

            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            services.AddScoped<IVocationWriteRepository, VocationWriteRepository>();
            services.AddScoped<IVocationReadRepository, VocationReadRepository>();
            services.AddScoped<IPermissionReadRepository, PermissionReadRepository>();
            services.AddScoped<IPermissionWriteRepository, PermissionWriteRepository>();
            services.AddScoped<IAdvanceReadRepository, AdvanceReadRepository>();
            services.AddScoped<IAdvanceWriteRepository, AdvanceWriteRepository>();
            services.AddScoped<IExpensesReadRepository, ExpensesReadRepository>();
            services.AddScoped<IExpensesWriteRepository, ExpensesWriteRepository>();
            services.AddScoped<ITypeofPermisionWriteRepository, TypeofPermissionWriteRepository>();
            services.AddScoped<ITypeofPermissionReadRepository, TypeofPermissionReadRepository>();

            
          
            return services;
        }



    }
}
   
