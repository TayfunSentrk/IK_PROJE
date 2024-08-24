using IKProje.Application.ViewModels.Personel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelDetails
{
    public class PersonelDetailQuery:IRequest<PersonelDetailViewModel>
    {
        public string UserName { get; set; }
    }
}
