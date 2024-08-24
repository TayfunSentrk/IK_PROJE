using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingle;
using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingle
{
    public class ExpensesGetSingleQueryHandler : IRequestHandler<ExpensesGetSingleQuery, ExpensesViewModel>
    {
        private readonly IMapper mapper;
        private readonly IExpensesReadRepository expensesReadRepository;

        public ExpensesGetSingleQueryHandler(IMapper mapper, IExpensesReadRepository expensesReadRepository)
        {
            this.mapper = mapper;
            this.expensesReadRepository = expensesReadRepository;
        }
        public async Task<ExpensesViewModel> Handle(ExpensesGetSingleQuery request, CancellationToken cancellationToken)
        {

            if (request.IsApproval)

            {
                return mapper.Map<ExpensesViewModel>(await expensesReadRepository.
              GetSingleInclude(x => x.Id == request.Id, include: query => query.Include(p => p.Personel), cancellationToken));
            }


            return mapper.Map<ExpensesViewModel>(await expensesReadRepository.GetAsync(f => f.Id ==request.Id, cancellationToken));

        }
    }
}
