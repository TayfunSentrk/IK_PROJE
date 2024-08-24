using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelSignIn
{
    public class PersonelSigInCommand : IRequest<SignInResult>
    {

        public string Email { get; set; } = default!;


        public string? Password { get; set; } = default!;


        public bool RememberMe { get; set; }
    }
}
