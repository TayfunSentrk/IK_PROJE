using AutoMapper;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelEdit
{
    public class PersonelEditCommandHandler : IRequestHandler<PersonelEditCommand, PersonelEditCommand>
    {
        private readonly UserManager<Personel> userManager;
        private readonly SignInManager<Personel> signInManager;
        private readonly IMapper mapper;
        private readonly IFileProvider fileProvider;

        public PersonelEditCommandHandler(UserManager<Personel> userManager,SignInManager<Personel> signInManager,IMapper mapper, IFileProvider fileProvider)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.fileProvider = fileProvider;
        }
        public async Task<PersonelEditCommand> Handle(PersonelEditCommand request, CancellationToken cancellationToken)
        {
            Personel? currentUser = await userManager.FindByNameAsync(request.UserName);

            currentUser.PicturePath=request.PicturePath;
            currentUser.PhoneNumber=request.PhoneNumber;
            currentUser.Address=request.Address;
            var updateToUserResult = await userManager.UpdateAsync(currentUser);
            await userManager.UpdateSecurityStampAsync(currentUser);
            // Çıkış yaptırıyoruz
            await signInManager.SignOutAsync();
            await signInManager.SignInAsync(currentUser, true);
            PersonelEditCommand personelCommand = mapper.Map<PersonelEditCommand>(currentUser);
            personelCommand.IdentityResult = updateToUserResult;

            return personelCommand;

        }
    }
}
