using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelPasswordChange
{
    public class PersonelPasswordChangeCommandHandler : IRequestHandler<PersonelPasswordChangeCommand, PersonelPasswordChangeCommandResponce>
    {
        private readonly UserManager<Personel> userManager;
        private readonly SignInManager<Personel> signInManager;

        public PersonelPasswordChangeCommandHandler(UserManager<Personel> userManager,SignInManager<Personel> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<PersonelPasswordChangeCommandResponce> Handle(PersonelPasswordChangeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByNameAsync(request.UserName);
            bool checkOldPassword = await userManager.CheckPasswordAsync(currentUser!, request.PasswordOld);
            PersonelPasswordChangeCommandResponce responce = new PersonelPasswordChangeCommandResponce();
            responce.checkOldPassword = checkOldPassword;
            if (checkOldPassword)
            {
                var result = await userManager.ChangePasswordAsync(currentUser, request.PasswordOld, request.PasswordNew);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(currentUser);
                    await signInManager.SignOutAsync();
                    await signInManager.PasswordSignInAsync(currentUser, request.PasswordNew, true, false);
                }
                 
                responce.result= result;
               
            }
          
          return  responce;
     
            
        }
    }
}
