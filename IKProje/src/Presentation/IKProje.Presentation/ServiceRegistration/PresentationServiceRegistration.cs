using IKProje.Application.Contract.CompanyRepositories;
using IKProje.Application.Contract.DepartmentRepositories;
using IKProje.Application.Contract.VocationRepositories;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.CompanyRepositories;
using IKProje.Persistance.Concrete.DepartmentRepositories;
using IKProje.Persistance.Concrete.VocationRepositories;
using IKProje.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace IKProje.Presentation.ServiceRegistration
{
    public static class PresentationServiceRegistration
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));



            services.AddIdentity<Personel, Role>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                // opt.User.AllowedUserNameCharacters = "asdfghjklşiğpoıuytrewqzxcvbnmöç";

                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireDigit = false;

                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                // Burada Lokout oldukdan sonra kullanıcı ne kadar süre boyuunca aynı email veya şifreyle siteye giriş yapamacağını bellirliyoruz.
                opt.Lockout.MaxFailedAccessAttempts = 3;
                // Kullanıcı şifre veya emailini 3 den fazla yanlış girerse aynı emaille siteye giriş yapmasına izin vermeyecek lokout süresi boyunca


            }).AddEntityFrameworkStores<IKProjeDbContext>().AddDefaultTokenProviders();


            // default olarak token üretmesini istedim bana kullanıcının şifresini unuttuğunda emailine link göndermek için
            // custom password,user,ve hataların dil seçeneğini yaptığımız yerleri program cs.e söylüyoruz.

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromHours(1);
            });
            // Burada oluşan tokenın ömrünü belirliyoruz 1 saatten sonra linke ulaşıldığında işlem yapılamasın.

            services.Configure<SecurityStampValidatorOptions>(opt =>
            {
                opt.ValidationInterval = TimeSpan.FromHours(1);
            });
            //Burada Security Stamp değerlerini karşılaştırır ve bu değerlerde bir değişiklik varsa kullanıcıyı login ekranına tekrar atar.Bu kontrol süresini burada 1 saat olarak ayarladık her bir saatte bir kontrol edecek. security stamp değerinin önemi örneğin bir web ve mobil uygulamanda kullanıcıya ait kritik bilgileri güncelledin ve bu sayede yeni bir security stamp değeri oluşturdun. Ama diğer uygulamada hala eski veriler var onun için uygulama bu sefer diğer ekranda da zorla tekrar login işlemi yapmayı sağlar 1 saatin sonunda. Kullanıcı güncelleme kodaları yazıldığında bu security stampi de güncelle.


            // Oluşan Cookielerin Optimize Edilmesi işlemi
            services.ConfigureApplicationCookie(opt =>
            {
                var cookieBuilder = new CookieBuilder();
                cookieBuilder.Name = "UdemyAppCookie";//Cookie Builder oluşturduk ve ismini verdik.
                opt.Cookie = cookieBuilder;//Cookieye atadık bunu
                opt.LoginPath = new PathString("/Home/Sigin");
                //Kullanıcı Login yapmadan bir sayfaya ulaşmak istediğinde bunu login sayfasına atacak direk.
                opt.ExpireTimeSpan = TimeSpan.FromDays(60);
                //Bir kullanıcı giriş yaptığında 60 gün boyunca bir cookieyi tarayıcıda tutacak ve giriş sayfasına atmadan işlemleri yapma hakkı verecek eğer 60 gün boyunca hiç giriş yapmazsa siteye cookie yok olacak ve tekrar giriş yaparak yeni cookie oluşturacak.
                opt.SlidingExpiration = true;
                // Bu işlemde de bir cookie oluştuktan sonra 60 gün boyunca kullanıcı bir kere bile giriş yapsa yeni bir 60 günlük seri başlatarak cookieyi ayakta tutacak böylece siteye login ekranına girmesine gerek kalmayacak

                //accessDenied sayfasının nerede olduğunu bildiriyorum artık

                opt.AccessDeniedPath = new PathString("/Member/AccessDenied");
            });



            return services;
        }

    }
}
