using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelSignIn
{
    public class PersonelSigInCommandHandler : IRequestHandler<PersonelSigInCommand, SignInResult>
    {
        private readonly SignInManager<Personel> signInManager;
        private readonly UserManager<Personel> userManager;

        public PersonelSigInCommandHandler(SignInManager<Personel> signInManager,UserManager<Personel> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<SignInResult> Handle(PersonelSigInCommand request, CancellationToken cancellationToken)
        {
            var hasUser = await userManager.FindByEmailAsync(request.Email!);//Cookie oluşturur başarılı ise.
            if (hasUser == null)

               
            {

              
                throw new ArgumentException("Email veya şifre yanlış.");
            }

            var result = await signInManager.PasswordSignInAsync(hasUser, request.Password!, request.RememberMe, true);

            return result;
        }
    }
}
