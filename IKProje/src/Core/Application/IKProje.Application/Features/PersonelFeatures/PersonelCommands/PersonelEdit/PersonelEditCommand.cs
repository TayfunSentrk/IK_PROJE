using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelEdit
{
    public class PersonelEditCommand:IRequest<PersonelEditCommand>
    {
        public string UserName { get; set; }
        public IdentityResult IdentityResult { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; } = default!;
        public string PicturePath { get; set; }
        public IFormFile? Picture { get; set; }



    }
}
