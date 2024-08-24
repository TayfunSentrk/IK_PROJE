using IKProje.Application.Contract.PersonelServices.Abstract;
using IKProje.Application.Exceptions;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelUpdatePassword
{
    public class PersonelUpdatePasswordCommandHandler : IRequestHandler<PersonelUpdatePasswordCommand, PersonelUpdatePasswordCommandResponse>
    {
        private readonly IPersonelService personelService;

        

        public PersonelUpdatePasswordCommandHandler(IPersonelService personelService, UserManager<Personel> userManager)
        {
            this.personelService = personelService;
           
        }
        public async Task<PersonelUpdatePasswordCommandResponse> Handle(PersonelUpdatePasswordCommand request, CancellationToken cancellationToken)
        {
         
            if (!request.Password.Equals(request.PasswordConfirm))
                throw new PasswordChangeFailedException("Liütfen girmiş olduğunuz şifrelerin aynı olduğundan emin olunuz");
            await personelService.UpdatePasswordAsync(request.UserId,request.Password);
            return new PersonelUpdatePasswordCommandResponse();
        }
    }
}
