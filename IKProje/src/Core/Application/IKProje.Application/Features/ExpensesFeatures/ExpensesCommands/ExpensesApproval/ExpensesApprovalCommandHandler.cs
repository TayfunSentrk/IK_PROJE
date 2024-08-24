using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval;
using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesApproval
{
    public class ExpensesApprovalCommandHandler : IRequestHandler<ExpensesApprovalCommand, ExpensesApprovalCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IExpensesReadRepository expensesReadRepository;
        private readonly IExpensesWriteRepository expensesWriteRepository;

        public ExpensesApprovalCommandHandler(IMapper mapper,IExpensesReadRepository expensesReadRepository,IExpensesWriteRepository expensesWriteRepository)
        {
            this.mapper = mapper;
            this.expensesReadRepository = expensesReadRepository;
            this.expensesWriteRepository = expensesWriteRepository;
        }
        public async Task<ExpensesApprovalCommandResponse> Handle(ExpensesApprovalCommand request, CancellationToken cancellationToken)
        {
            Expenses? update = await expensesReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (update == null) throw new Exception("Güncellenecek öğe Bulunamadı");
            ExpensesApprovalCommandResponse response = new ExpensesApprovalCommandResponse();
            update.StatusofApproval = request.StatusofApproval;
            update.LastUpdatedTime = DateTime.Now;
            update.DateofReply = DateTime.Now;
            bool IsUpdate = expensesWriteRepository.Update(update, cancellationToken);
            await expensesWriteRepository.SaveAsync(cancellationToken);
            response.Success = IsUpdate;
            response.Message = IsUpdate ? "İşlem başarılı" : "İşlem Başarısız";
            response.Response = mapper.Map<ExpensesViewModel>(update);
            return response;
        }
    }
}
