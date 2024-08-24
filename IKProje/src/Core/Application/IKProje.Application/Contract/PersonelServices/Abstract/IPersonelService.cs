using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Contract.PersonelServices.Abstract
{
    public interface IPersonelService
    {
      Task< string> ConvertToEnglish(string input);
       Task< string> MakeUserName(PersonelCreateCommand input);
       Task< string> MakeEmail(PersonelCreateCommand input, string mailTarz);


        Task PasswordResetAsync(string email);
                
        Task UpdatePasswordAsync(string userId,string newPassword);
    }
}
