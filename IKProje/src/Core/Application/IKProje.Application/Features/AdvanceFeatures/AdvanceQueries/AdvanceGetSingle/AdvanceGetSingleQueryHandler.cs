using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.Common;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.ViewModels;
using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.ExpensesViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingle
{
    public class AdvanceGetSingleQueryHandler : IRequestHandler<AdvanceGetSingleQuery, AdvanceViewModel>
    {
        private readonly IMapper mapper;
        private readonly IAdvanceReadRepository advanceReadRepository;

        public AdvanceGetSingleQueryHandler(IMapper mapper, IAdvanceReadRepository advanceReadRepository)
        {
            this.mapper = mapper;
            this.advanceReadRepository = advanceReadRepository;
        }
        public async Task<AdvanceViewModel> Handle(AdvanceGetSingleQuery request, CancellationToken cancellationToken)
        {
          

            if (request.IsApproval)

            {
                return mapper.Map<AdvanceViewModel>(await advanceReadRepository.
              GetSingleInclude(x => x.Id == request.Id, include: query => query.Include(p => p.Personel), cancellationToken));
            }


            return mapper.Map<AdvanceViewModel>(await advanceReadRepository.GetAsync(f => f.Id == request.Id, cancellationToken));
        }
    }
}
