using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.Common;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentEdit;
using IKProje.Application.Wrapper;
using IKProje.Domain.Entities.Base.Enums;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit
{
    public class AdvanceEditCommandHandler : IRequestHandler<AdvanceEditCommand, AdvanceEditCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IAdvanceWriteRepository advanceWriteRepository;
        private readonly IAdvanceReadRepository advanceReadRepository;

        public AdvanceEditCommandHandler(IMapper mapper,IAdvanceWriteRepository advanceWriteRepository,IAdvanceReadRepository advanceReadRepository)
        {
            this.mapper = mapper;
            this.advanceWriteRepository = advanceWriteRepository;
            this.advanceReadRepository = advanceReadRepository;
        }
        public async Task<AdvanceEditCommandResponse> Handle(AdvanceEditCommand request, CancellationToken cancellationToken)
        {
            Advance? update = await advanceReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (update == null) throw new Exception("Güncellenecek öğe Bulunamadı");
            AdvanceEditCommandResponse response = new AdvanceEditCommandResponse();
            if (update.StatusofApproval!=Approval.AwaitingApproval)
            {
                response.Success = false;
                response.Message = "Onaylanmış veya reddedilmiş  avansları güncelleyemezsiniz";
                return response;
            }

            mapper.Map(request, update);
            
            update.LastUpdatedTime = DateTime.Now;
            update.Name = request.TypeofAdvance.ToString();
            bool IsUpdate = advanceWriteRepository.Update(update, cancellationToken);
            await advanceWriteRepository.SaveAsync(cancellationToken);
            response.Success = IsUpdate;
            response.Message = IsUpdate ? "İşlem başarılı" : "İşlem Başarısız";
            return response;
        }
    }
}
