using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingleForEdit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingleForEdit
{
    public class AdvanceGetSingleForEditCommandHandler : IRequestHandler<AdvanceGetSingleForEditCommand, AdvanceViewForEdit>
    {

        private readonly IAdvanceReadRepository advanceReadRepository;
        private readonly IMapper mapper;

        public AdvanceGetSingleForEditCommandHandler(IAdvanceReadRepository advanceReadRepository, IMapper mapper)
        {
            this.advanceReadRepository = advanceReadRepository;
            this.mapper = mapper;
        }

        public async Task<AdvanceViewForEdit> Handle(AdvanceGetSingleForEditCommand request, CancellationToken cancellationToken)
        {
            return mapper.Map<AdvanceViewForEdit>(await advanceReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken, request.IsTracking));
        }

       
    }
}
