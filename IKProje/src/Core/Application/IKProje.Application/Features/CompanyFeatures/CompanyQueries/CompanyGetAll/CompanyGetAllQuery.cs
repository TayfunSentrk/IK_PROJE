using IKProje.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll
{
    public class CompanyGetAllQuery:IRequest<IEnumerable<CompanyViewModel>>
    {
        public bool Tracking { get; set; } = true;
    }
}
