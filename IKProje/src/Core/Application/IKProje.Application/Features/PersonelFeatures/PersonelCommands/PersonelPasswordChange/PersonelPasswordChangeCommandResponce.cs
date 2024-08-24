using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelPasswordChange
{
    public class PersonelPasswordChangeCommandResponce
    {
        public IdentityResult result { get; set; }
        public bool checkOldPassword { get; set; }
    }
}
