using AutoMapper;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesDelete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionDelete
{
    public class PermissionDeleteCommandHandler : IRequestHandler<PermissionDeleteCommand, PermissionDeleteCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IPermissionWriteRepository permissionWriteRepository;

        public PermissionDeleteCommandHandler(IMapper mapper, IPermissionWriteRepository permissionWriteRepository)
        {
            this.mapper = mapper;
            this.permissionWriteRepository = permissionWriteRepository;
        }
        public async Task<PermissionDeleteCommandResponse> Handle(PermissionDeleteCommand request, CancellationToken cancellationToken)
        {
            bool success = permissionWriteRepository.RemoveById(request.Id, cancellationToken);
            await permissionWriteRepository.SaveAsync(cancellationToken);
            PermissionDeleteCommandResponse responce = new PermissionDeleteCommandResponse
            {
                Success = success,
                Message = success ? "İşlem Başarılı" : "İşlem Başarısız"
            };


            return responce;
        }
    }
}
