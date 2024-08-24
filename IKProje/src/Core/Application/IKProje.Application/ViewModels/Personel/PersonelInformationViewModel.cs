using IKProje.Domain.Entities.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.ViewModels.Personel
{
    public class PersonelInformationViewModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; } = default!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = default!;
        public string? SecondLastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; } = default!;
        public string PicturePath { get; set; }
        public IFormFile? Picture { get; set; }


     
    }
}
