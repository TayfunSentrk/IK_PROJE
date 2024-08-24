using AutoMapper;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Contract.TypeofPermissionRepository;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionDelete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionDelete
{
    public class TypeofPermissionDeleteCommandHandler : IRequestHandler<TypeofPermissionDeleteCommand, TypeofPermissionDeleteCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ITypeofPermisionWriteRepository typeofPermisionWriteRepository;

        public TypeofPermissionDeleteCommandHandler(IMapper mapper, ITypeofPermisionWriteRepository typeofPermisionWriteRepository)
        {
            this.mapper = mapper;
            this.typeofPermisionWriteRepository = typeofPermisionWriteRepository;
        }
        public async Task<TypeofPermissionDeleteCommandResponse> Handle(TypeofPermissionDeleteCommand request, CancellationToken cancellationToken)
        {
            bool success = typeofPermisionWriteRepository.RemoveById(request.Id, cancellationToken);
            await typeofPermisionWriteRepository.SaveAsync(cancellationToken);
            TypeofPermissionDeleteCommandResponse responce = new TypeofPermissionDeleteCommandResponse
            {
                Success = success,
                Message = success ? "İşlem Başarılı" : "İşlem Başarısız"
            };


            return responce;
        }
    }
}
