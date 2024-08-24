using IKProje.Application.Contract.MailServices;
using IKProje.Application.Contract.PersonelServices.Abstract;
using IKProje.Application.Exceptions;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate;
using IKProje.Domain.Entities.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.WebEncoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Contract.PersonelServices.Concrete
{
    public class PersonelService : IPersonelService
    {
        private readonly UserManager<Personel> userManager;
        private readonly IMailService mailService;

        public PersonelService(UserManager<Personel> userManager,IMailService mailService)
        {
            this.userManager = userManager;
            this.mailService = mailService;
        }
        public async Task< string> ConvertToEnglish(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                switch (c)
                {
                    case 'İ':
                        result.Append('I');
                        break;
                    case 'ı':
                        result.Append('i');
                        break;
                    case 'Ğ':
                        result.Append('G');
                        break;
                    case 'ğ':
                        result.Append('g');
                        break;
                    case 'Ü':
                        result.Append('U');
                        break;
                    case 'ü':
                        result.Append('u');
                        break;
                    case 'Ş':
                        result.Append('S');
                        break;
                    case 'ş':
                        result.Append('s');
                        break;
                    case 'Ö':
                        result.Append('O');
                        break;
                    case 'ö':
                        result.Append('o');
                        break;
                    default:
                        result.Append(c);
                        break;
                }
            }
            return result.ToString();
        }

        public async Task<string >MakeEmail(PersonelCreateCommand input,string mailTarz)
        {
            StringBuilder email = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(input.FirstName))  email.Append(input.FirstName.ToLower());
            if (!string.IsNullOrWhiteSpace(input.SecondName))  email.Append(input.SecondName.ToLower());
            if (!string.IsNullOrWhiteSpace(input.LastName)) email.Append("." + input.LastName.ToLower());
            if (!string.IsNullOrWhiteSpace(input.SecondLastName)) email.Append("." + input.SecondLastName.ToLower());

            return await ConvertToEnglish(email.ToString()) + $"@{mailTarz}.com"; 

        }

        public async Task<string> MakeUserName(PersonelCreateCommand input)
        {
            StringBuilder userName = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(input.FirstName))  userName.Append(await ConvertToEnglish(input.FirstName)); 
            if (!string.IsNullOrWhiteSpace(input.SecondName))  userName.Append(await ConvertToEnglish(input.SecondName)); 
            if (!string.IsNullOrWhiteSpace(input.LastName))  userName.Append(await ConvertToEnglish(input.LastName)); 
            if (!string.IsNullOrWhiteSpace(input.SecondLastName))  userName.Append(await ConvertToEnglish(input.SecondLastName)); 
            return userName.ToString();
        }

        public async Task PasswordResetAsync(string email)
        {
         var currentUser= await userManager.FindByEmailAsync(email);
           if (currentUser != null)
            {              
                               
                await mailService.SendPasswordResetMailAsync(email,currentUser.Id);
            }
        }

           
        public async Task UpdatePasswordAsync(string userId, string newPassword)
        { Personel personel=await userManager.FindByIdAsync(userId);
            if (personel != null)
            {


                var removePasswordResult = await userManager.RemovePasswordAsync(personel);
                if (!removePasswordResult.Succeeded)
                {
                    throw new Exception("Şifre değiştirilemedi");
                    // Şimdi yeni şifreyi ekleyin
                   
                    
                }

                var addPasswordResult = await userManager.AddPasswordAsync(personel, newPassword);
                if (!addPasswordResult.Succeeded)
                {
                    throw new Exception("Şifre değiştirilemedi");
                }
                await userManager.UpdateSecurityStampAsync(personel);

              
               
            }

            else
            {
                throw new Exception("Kullanici Bulunamadı");
            }
        }
    }
}
