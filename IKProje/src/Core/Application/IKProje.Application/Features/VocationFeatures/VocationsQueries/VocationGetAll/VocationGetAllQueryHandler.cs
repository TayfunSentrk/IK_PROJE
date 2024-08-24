using AutoMapper;
using IKProje.Application.Contract.VocationRepositories;
using IKProje.Application.ViewModels;
using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetAll
{
    public class VocationGetAllQueryHandler : IRequestHandler<VocationGetAllQuery, IEnumerable<VocationViewModel>>
    {
        private readonly IVocationReadRepository readRepository;
        private readonly IMapper mapper;

        public VocationGetAllQueryHandler(IVocationReadRepository readRepository,IMapper mapper)
        {
            this.readRepository = readRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<VocationViewModel>>Handle(VocationGetAllQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<VocationViewModel>>(await readRepository.GetAllAsync(cancellationToken, request.Tracking));
        }
    }
}
