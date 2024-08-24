using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate
{
    public class CompanyCreateCommand:IRequest<CompanyCreateCommandResponse>
    {
        public string Name { get; set; } = default!;
        public string Unvan { get; set; }
        public string MersisNo { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string Adres { get; set; }
        public IFormFile Picture { get; set; }
        public string? LogoPath { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int CalisanSayisi { get; set; }
        public DateTime KurulusTarihi { get; set; }
        public DateTime SozlesmeBaslangic { get; set; }
        public DateTime SozlesmeBitis { get; set; }
    }
}
