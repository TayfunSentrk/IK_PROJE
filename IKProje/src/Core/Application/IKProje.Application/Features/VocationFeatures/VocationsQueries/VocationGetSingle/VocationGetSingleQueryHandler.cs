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

namespace IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetSingle
{
    public class VocationGetSingleQueryHandler : IRequestHandler<VocationGetSingleQuery, VocationViewModel>
    {
        private readonly IVocationReadRepository readRepository;
        private readonly IMapper mapper;

        public VocationGetSingleQueryHandler(IVocationReadRepository readRepository,IMapper mapper)
        {
            this.readRepository = readRepository;
            this.mapper = mapper;
        }
        public async Task<VocationViewModel> Handle(VocationGetSingleQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<VocationViewModel>(await readRepository.GetAsync(x => x.Id == request.Id, cancellationToken));
        }
    }
}
