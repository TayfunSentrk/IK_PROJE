using AutoMapper;
using IKProje.Application.Contract.CompanyRepositories;
using IKProje.Application.Contract.DepartmentRepositories;
using IKProje.Application.Contract.MailServices;
using IKProje.Application.Contract.PersonelServices.Abstract;
using IKProje.Application.Contract.VocationRepositories;
using IKProje.Application.Exceptions;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetSingle;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetSingle;
using IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetSingle;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate
{
    public class PersonelCreateCommandHandler : IRequestHandler<PersonelCreateCommand, IdentityResult>
    {
        private readonly UserManager<Personel> userManager;

        private readonly IMapper mapper;

        private readonly IMediator mediator;
        private readonly ICompanyReadRepository companyReadRepository;
        private readonly IDepartmentReadRepository departmentReadrepository;
        private readonly IVocationReadRepository vocationReadRepository;
        private readonly IPersonelService personelService;
        private readonly IVocationReadRepository vocationReadrepository;
        private readonly IMailService mailService;



        public PersonelCreateCommandHandler(UserManager<Personel> userManager, IMapper mapper, IMediator mediator, IDepartmentReadRepository departmentReadrepository, IVocationReadRepository vocationReadRepository, IPersonelService personelService, ICompanyReadRepository companyReadRepository, IMailService mailService)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.mediator = mediator;
            this.departmentReadrepository = departmentReadrepository;
            this.vocationReadRepository = vocationReadRepository;
            this.personelService = personelService;
            this.companyReadRepository = companyReadRepository;
            this.mailService = mailService;
        }
        public async Task<IdentityResult> Handle(PersonelCreateCommand request, CancellationToken cancellationToken)
        {
            var managerUser = await userManager.FindByNameAsync(request.ManagerUserName);

            var personel=mapper.Map<Personel>(request);

            personel.Vocation = await vocationReadRepository.GetAsync(x=>x.Id== personel.VocationId);
                //mapper.Map<Vocation>(await mediator.Send(new VocationGetSingleQuery { Id=personel.VocationId}));
            personel.Department = await departmentReadrepository.GetAsync(x => x.Id == personel.DepartmanId);


            if (managerUser==null)
            {
                personel.Company = await companyReadRepository.GetAsync(x => x.Id == personel.CompanyId);
            }
            else
            {
                personel.Company = managerUser.Company;
                personel.CompanyId = managerUser.CompanyId;
            }
           
            // mapper.Map<Department>(await mediator.Send(new DepartmentGetSingleQuery { Id=personel.DepartmanId }));
            //personel.Company = managerUser.Company;
            //personel.CompanyId = managerUser.CompanyId;

            personel.UserName = await personelService.MakeUserName(request);
           
            //request.Password = GenerateRandomPassword(6);
            //request.PasswordConfirm = request.Password;
            personel.Email = await personelService.MakeEmail(request,"bilgeadamboost");
            
            
            IdentityResult? result=await userManager.CreateAsync(personel,request.Password);
            if (!result.Succeeded)
            {
              List<string> errorList= result.Errors.Select(x=>x.Description).ToList();
                throw new Exception("Kullanici Kayıdı Başarısız Oldu");
            }

            if (managerUser==null)
            {
                 await userManager.AddToRoleAsync(personel, "Yönetici");
            }



            //var htmlBody = $"<div class='container'>" +
            //    " <div class='header'>Hesap Bilgileriniz</div> " +
            //    $" <div class='content'>" + $"<div class='info'>  <span class='info-label'>Kullanıcı Adı:</span> {personel.Email}" +
            //    $" </div> <div class=info'> <span class='info-label'>Şifre:</span>{request.Password}" +
            //    " </div> </div></div>";
            //await mailService.SendMailAsync("taysen9090@hotmail.com", "Sifre Yenileme", htmlBody);
            await personelService.PasswordResetAsync(personel.Email);

            return result;

        }

        static string GenerateRandomPassword(int length)
        {
            Random rnd = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
            string randomPassword = "";

            for (int i = 0; i < length; i++)
            {
                int randomIndex = rnd.Next(characters.Length);
                randomPassword += characters[randomIndex];
            }

            return randomPassword;
        }

    }
}
