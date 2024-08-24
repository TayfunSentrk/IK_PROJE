using MediatR;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelUpdatePassword
{
    public class PersonelUpdatePasswordCommand:IRequest<PersonelUpdatePasswordCommandResponse>
    {
        public string? UserId { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}