using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.Common;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyDelete;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceDelete
{
    public class AdvanceDeleteCommandHandler : IRequestHandler<AdvanceDeleteCommand, AdvanceDeleteCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IAdvanceWriteRepository advanceWriteRepository;
        private readonly IAdvanceReadRepository advanceReadRepository;

        public AdvanceDeleteCommandHandler(IMapper mapper,IAdvanceWriteRepository advanceWriteRepository,IAdvanceReadRepository advanceReadRepository)
        {
            this.mapper = mapper;
            this.advanceWriteRepository = advanceWriteRepository;
            this.advanceReadRepository = advanceReadRepository;
        }
        public async Task<AdvanceDeleteCommandResponse> Handle(AdvanceDeleteCommand request, CancellationToken cancellationToken)
        {
            var advance = await advanceReadRepository.GetAsync(x=>x.Id==request.Id);
            AdvanceDeleteCommandResponse responce = new AdvanceDeleteCommandResponse();
            if (advance.StatusofApproval != Approval.AwaitingApproval)
            {
                responce.Success = false;
                responce.Message = "Onaylanmış veya reddedilmiş avansları iptal edemezsiniz."; 
                return responce;
            }
            bool success = advanceWriteRepository.RemoveById(request.Id, cancellationToken);
            await advanceWriteRepository.SaveAsync(cancellationToken);

            responce.Success = success;
            responce.Message = success ? "İşlem Başarılı" : "İşlem Başarısız";
      
            return responce;
        }
    }
}
