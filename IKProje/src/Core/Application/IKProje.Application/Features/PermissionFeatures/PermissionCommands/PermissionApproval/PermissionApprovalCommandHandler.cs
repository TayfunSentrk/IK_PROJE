using AutoMapper;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesApproval;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Application.ViewModels.PermissionViewModels;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionApproval
{
    public class PermissionApprovalCommandHandler : IRequestHandler<PermissionApprovalCommand, PermissionApprovalCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IPermissionReadRepository permissionReadRepository;
        private readonly IPermissionWriteRepository permissionWriteRepository;

        public PermissionApprovalCommandHandler(IMapper mapper,IPermissionReadRepository permissionReadRepository,IPermissionWriteRepository permissionWriteRepository)
        {
            this.mapper = mapper;
            this.permissionReadRepository = permissionReadRepository;
            this.permissionWriteRepository = permissionWriteRepository;
        }
        public async Task<PermissionApprovalCommandResponse> Handle(PermissionApprovalCommand request, CancellationToken cancellationToken)
        {
            Permission? update = await permissionReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (update == null) throw new Exception("Güncellenecek öğe Bulunamadı");
            PermissionApprovalCommandResponse response = new PermissionApprovalCommandResponse();
            update.StatusofApproval = request.StatusofApproval;
            update.LastUpdatedTime = DateTime.Now;
            update.DateofReply = DateTime.Now;
            bool IsUpdate = permissionWriteRepository.Update(update, cancellationToken);
            await permissionWriteRepository.SaveAsync(cancellationToken);
            response.Success = IsUpdate;
            response.Message = IsUpdate ? "İşlem başarılı" : "İşlem Başarısız";
            response.Response = mapper.Map<PermissionViewModel>(update);
            return response;
        }
    }
}
