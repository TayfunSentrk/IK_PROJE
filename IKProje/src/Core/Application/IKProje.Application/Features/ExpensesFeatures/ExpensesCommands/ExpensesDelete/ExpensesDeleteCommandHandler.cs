using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceDelete;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesDelete
{
    public class ExpensesDeleteCommandHandler : IRequestHandler<ExpensesDeleteCommand, ExpensesDeleteCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IExpensesWriteRepository expensesWriteRepository;
        private readonly IExpensesReadRepository expensesReadRepository;

        public ExpensesDeleteCommandHandler(IMapper mapper, IExpensesWriteRepository expensesWriteRepository,IExpensesReadRepository expensesReadRepository)
        {
            this.mapper = mapper;
            this.expensesWriteRepository = expensesWriteRepository;
            this.expensesReadRepository = expensesReadRepository;
        }
        public async Task<ExpensesDeleteCommandResponse> Handle(ExpensesDeleteCommand request, CancellationToken cancellationToken)
        {
            var expenses = await expensesReadRepository.GetAsync(x => x.Id == request.Id);
            ExpensesDeleteCommandResponse responce = new ExpensesDeleteCommandResponse();
            if (expenses.StatusofApproval != Approval.AwaitingApproval)
            {
                responce.Success = false;
                responce.Message = "Onaylanmış veya reddedilmiş avansları iptal edemezsiniz.";
                return responce;
            }



            bool success = expensesWriteRepository.RemoveById(request.Id, cancellationToken);
            await expensesWriteRepository.SaveAsync(cancellationToken);

            responce.Success = success;
            responce.Message = success ? "İşlem Başarılı" : "İşlem Başarısız";
            return responce;
        }
    }
}
