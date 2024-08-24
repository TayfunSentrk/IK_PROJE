using FluentValidation;
using FluentValidation.AspNetCore;
using IKProje.Application.Behaviours;
using IKProje.Application.Contract.MailServices;
using IKProje.Application.Contract.PersonelServices.Abstract;
using IKProje.Application.Contract.PersonelServices.Concrete;
using IKProje.Application.Validations.PersonelValidations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.ServiceRegistration
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationSevices(this IServiceCollection serviceCollection)
        {
            var assm = Assembly.GetExecutingAssembly();
            serviceCollection.AddFluentValidation(x => x.RegisterValidatorsFromAssembly(assm));
            serviceCollection.AddMediatR(assm);
            serviceCollection.AddAutoMapper(assm);
            serviceCollection.AddScoped<IPersonelService,PersonelService>();
            serviceCollection.AddScoped<IMailService, MailService>();
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            //deneme

            serviceCollection.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { new CultureInfo("tr-TR") };
                options.DefaultRequestCulture = new RequestCulture("tr-TR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });



        }
    }
}
