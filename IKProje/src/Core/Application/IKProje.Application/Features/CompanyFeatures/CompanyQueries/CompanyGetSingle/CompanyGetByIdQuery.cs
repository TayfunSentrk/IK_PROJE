using IKProje.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetSingle
{
    public class CompanyGetByIdQuery:IRequest<CompanyViewModel>
    {
        public string Id { get; set; }

    }
}
