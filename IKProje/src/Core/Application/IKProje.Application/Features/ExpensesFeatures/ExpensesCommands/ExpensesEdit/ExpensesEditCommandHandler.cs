using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;
using IKProje.Domain.Entities.Base.Enums;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesEdit
{
    public class ExpensesEditCommandHandler : IRequestHandler<ExpensesEditCommand, ExpensesEditCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IExpensesWriteRepository expensesWriteRepository;
        private readonly IExpensesReadRepository expensesReadRepository;

        public ExpensesEditCommandHandler(IMapper mapper, IExpensesWriteRepository expensesWriteRepository,IExpensesReadRepository expensesReadRepository)
        {
            this.mapper = mapper;
            this.expensesWriteRepository = expensesWriteRepository;
            this.expensesReadRepository = expensesReadRepository;
        }
        public async Task<ExpensesEditCommandResponse> Handle(ExpensesEditCommand request, CancellationToken cancellationToken)
        {
            Expenses? update = await expensesReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            ExpensesEditCommandResponse response = new ExpensesEditCommandResponse();
            if (update == null) throw new Exception("Güncellenecek öğe Bulunamadı");
            if (update.StatusofApproval != Approval.AwaitingApproval)
            {
                response.Success = false;
                response.Message = "Onaylanmış veya reddedilmiş  avansları güncelleyemezsiniz";
                return response;
            }

            mapper.Map(request, update);
            update.LastUpdatedTime = DateTime.Now;
            update.Name = request.TypeofExpenses.ToString();
            
            bool IsUpdate = expensesWriteRepository.Update(update, cancellationToken);
            await expensesWriteRepository.SaveAsync(cancellationToken);
            response.Success = IsUpdate;
            response.Message = IsUpdate ? "İşlem başarılı" : "İşlem Başarısız";
          
            return response;

           
        }
    }
}
