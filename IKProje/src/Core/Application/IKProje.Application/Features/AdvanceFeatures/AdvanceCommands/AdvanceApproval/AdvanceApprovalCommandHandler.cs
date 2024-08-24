using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;
using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Domain.Entities.Base.Enums;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval
{
    public class AdvanceApprovalCommandHandler : IRequestHandler<AdvanceApprovalCommand, AdvanceApprovalCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IAdvanceWriteRepository advanceWriteRepository;
        private readonly IAdvanceReadRepository advanceReadRepository;
        private readonly UserManager<Personel> userManager;

        public AdvanceApprovalCommandHandler(IMapper mapper,IAdvanceWriteRepository advanceWriteRepository,IAdvanceReadRepository advanceReadRepository,UserManager<Personel> userManager)
        {
            this.mapper = mapper;
            this.advanceWriteRepository = advanceWriteRepository;
            this.advanceReadRepository = advanceReadRepository;
            this.userManager = userManager;
        }
        public async Task<AdvanceApprovalCommandResponse> Handle(AdvanceApprovalCommand request, CancellationToken cancellationToken)
        {
            Advance? update = await advanceReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            //Personel? personel = await userManager.FindByIdAsync(request.PersonelId);
            Personel? personel = await userManager.FindByNameAsync(request.PersonelName);
            if (update == null) throw new Exception("Güncellenecek öğe Bulunamadı");
            AdvanceApprovalCommandResponse response = new AdvanceApprovalCommandResponse();
          
            update.StatusofApproval=request.StatusofApproval;
            if (update.TypeofAdvance==TypeofAdvance.IndividualAdvance)
            {
                if (request.StatusofApproval == Approval.Approved)
                {
                    Tuple<Personel, Advance> resultofTuple = await advanceWriteRepository.ControlofAdvance(personel, update);
                    personel = resultofTuple.Item1;
                    update = resultofTuple.Item2;
                }
            }
         
            update.LastUpdatedTime = DateTime.Now;
            update.DateofReply = DateTime.Now;
            var result = await userManager.UpdateAsync(personel);
            await userManager.UpdateSecurityStampAsync(personel);
            bool IsUpdate = advanceWriteRepository.Update(update, cancellationToken);
            await advanceWriteRepository.SaveAsync(cancellationToken);
            response.Success = IsUpdate;
            response.Message = IsUpdate ? "İşlem başarılı" : "İşlem Başarısız";
            response.Response = mapper.Map<AdvanceViewModel>(update);
            return response;
        }
    }
}
