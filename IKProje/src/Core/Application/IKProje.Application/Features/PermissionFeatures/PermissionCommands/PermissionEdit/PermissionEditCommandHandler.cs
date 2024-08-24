using AutoMapper;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Contract.TypeofPermissionRepository;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesEdit;
using IKProje.Domain.Entities.Base.Enums;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit
{
    public class PermissionEditCommandHandler : IRequestHandler<PermissionEditCommand, PermissionEditCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IPermissionWriteRepository permissionWriteRepository;
        private readonly IPermissionReadRepository permissionReadRepository;
        private readonly ITypeofPermissionReadRepository typeofPermissionReadRepository;
        public PermissionEditCommandHandler(IMapper mapper, IPermissionWriteRepository permissionWriteRepository, IPermissionReadRepository permissionReadRepository, ITypeofPermissionReadRepository typeofPermissionReadRepository)
        {
            this.mapper = mapper;
            this.permissionWriteRepository = permissionWriteRepository;
            this.permissionReadRepository = permissionReadRepository;
            this.typeofPermissionReadRepository = typeofPermissionReadRepository;
        }
        public async Task<PermissionEditCommandResponse> Handle(PermissionEditCommand request, CancellationToken cancellationToken)
        {
            Permission? update = await permissionReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            TypeofPermission typeofPermission = await typeofPermissionReadRepository.GetAsync(x => x.Id == request.TypeofPermissionId);

            PermissionEditCommandResponse response = new PermissionEditCommandResponse();
            if (update == null) throw new Exception("Güncellenecek öğe Bulunamadı");
            if (update.StatusofApproval != Approval.AwaitingApproval)
            {
                response.Success = false;
                response.Message = "Onaylanmış veya reddedilmiş avansları güncelleyemezsiniz";
                return response;
            }

            // Map changes to the tracked entity
            mapper.Map(request, update); // Assuming AutoMapper is being used
            update.DayCount = typeofPermission.Duration;
            update.FinishedDate = update.StartedDate.AddDays(update.DayCount);
            
            update.Name = typeofPermission.Name;
            update.LastUpdatedTime = DateTime.Now;

            bool IsUpdate = permissionWriteRepository.Update(update, cancellationToken);
            await permissionWriteRepository.SaveAsync(cancellationToken);
            response.Success = IsUpdate;
            response.Message = IsUpdate ? "İşlem başarılı" : "İşlem Başarısız";
            return response;

        }
    }
}
