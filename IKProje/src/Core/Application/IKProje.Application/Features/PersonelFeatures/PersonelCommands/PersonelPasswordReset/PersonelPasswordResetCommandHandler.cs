using IKProje.Application.Contract.PersonelServices.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelPasswordReset
{
    public class PersonelPasswordResetCommandHandler : IRequestHandler<PersonelPasswordResetCommand, PersonelPasswordResetCommandResponse>
    {
        private readonly IPersonelService personelService;

        public PersonelPasswordResetCommandHandler(IPersonelService personelService)
        {
            this.personelService = personelService;
        }
        public async Task<PersonelPasswordResetCommandResponse> Handle(PersonelPasswordResetCommand request, CancellationToken cancellationToken)
        {
            await personelService.PasswordResetAsync(request.Email);
            return new();
        }
    }


}
