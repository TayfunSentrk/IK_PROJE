using AutoMapper;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingleForEdit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingleForEdit
{
    public class ExpensesGetSingleForEditCommandHandler : IRequestHandler<ExpensesGetSingleForEditCommand, ExpensesViewForEdit>
    {

        private readonly IExpensesReadRepository expensesReadRepository;
        private readonly IMapper mapper;


        public ExpensesGetSingleForEditCommandHandler(IExpensesReadRepository expensesReadRepository, IMapper mapper)
        {
            this.expensesReadRepository = expensesReadRepository;
            this.mapper = mapper;
        }
        public async Task<ExpensesViewForEdit> Handle(ExpensesGetSingleForEditCommand request, CancellationToken cancellationToken)
        {
            return mapper.Map<ExpensesViewForEdit>(await expensesReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken, request.IsTracking));

        }


      

          
    }
}
