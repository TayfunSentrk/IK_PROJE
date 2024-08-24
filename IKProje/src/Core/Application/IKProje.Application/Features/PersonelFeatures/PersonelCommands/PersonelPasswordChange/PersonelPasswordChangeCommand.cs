using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelPasswordChange
{
    public class PersonelPasswordChangeCommand:IRequest<PersonelPasswordChangeCommandResponce>
    {
        public string UserName { get; set; }
        public string PasswordOld { get; set; }

        
        public string PasswordNew { get; set; }
        
        public string PasswordConfirm { get; set; }
    }
}
