using AutoMapper;
using IKProje.Application.Contract.CompanyRepositories;
using IKProje.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll
{
    public class CompanyGetAllQueryHandler : IRequestHandler<CompanyGetAllQuery, IEnumerable<CompanyViewModel>>
    {
        private readonly ICompanyReadRepository readRepository;
        private readonly IMapper mapper;

        public CompanyGetAllQueryHandler(ICompanyReadRepository readRepository,IMapper mapper)
        {
            this.readRepository = readRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CompanyViewModel>> Handle(CompanyGetAllQuery request, CancellationToken cancellationToken)
        {
           return mapper.Map<IEnumerable<CompanyViewModel>>(await readRepository.GetAllAsync(cancellationToken, request.Tracking));
        }
    }
}
