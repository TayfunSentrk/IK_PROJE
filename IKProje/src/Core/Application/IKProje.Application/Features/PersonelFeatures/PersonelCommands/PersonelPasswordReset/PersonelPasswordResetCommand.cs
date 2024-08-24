using MediatR;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelPasswordReset
{
    public class PersonelPasswordResetCommand:IRequest<PersonelPasswordResetCommandResponse>
    {
        public string Email { get; set; }
    }
}