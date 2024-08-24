using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.ViewModels.Personel
{
    public class PersonelInformationForEdit
    {
        public string PhoneNumber { get; set; }
        public string Address { get; set; } = default!;
        public string? PicturePath { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
