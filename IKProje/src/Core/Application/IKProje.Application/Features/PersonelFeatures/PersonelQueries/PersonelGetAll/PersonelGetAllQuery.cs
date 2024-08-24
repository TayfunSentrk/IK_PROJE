using IKProje.Application.ViewModels.Personel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelGetAll
{
    public class PersonelGetAllQuery:IRequest<List<PersonelViewModel>>
    {
        public string UserName { get; set; }
        public string? CompanyId { get; set; }
    }
}
