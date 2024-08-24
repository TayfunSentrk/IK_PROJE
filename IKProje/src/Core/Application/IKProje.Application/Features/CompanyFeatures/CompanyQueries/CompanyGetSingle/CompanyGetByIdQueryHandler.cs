using AutoMapper;
using IKProje.Application.Contract.CompanyRepositories;
using IKProje.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetSingle
{
    public class CompanyGetByIdQueryHandler : IRequestHandler<CompanyGetByIdQuery, CompanyViewModel>
    {
        private readonly ICompanyReadRepository readRepository;
        private readonly IMapper mapper;

        public CompanyGetByIdQueryHandler(ICompanyReadRepository readRepository,IMapper mapper)
        {
            this.readRepository = readRepository;
            this.mapper = mapper;
        }
        public async Task<CompanyViewModel> Handle(CompanyGetByIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<CompanyViewModel>( await readRepository.GetAsync(x=>x.Id==request.Id,cancellationToken));
        }
    }
}
