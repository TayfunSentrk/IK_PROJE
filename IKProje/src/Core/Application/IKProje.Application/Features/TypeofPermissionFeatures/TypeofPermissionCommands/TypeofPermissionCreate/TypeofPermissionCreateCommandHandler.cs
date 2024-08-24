using AutoMapper;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Contract.TypeofPermissionRepository;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionCreate
{
    public class TypeofPermissionCreateCommandHandler : IRequestHandler<TypeofPermissionCreateCommand, TypeofPermissionCreateCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ITypeofPermisionWriteRepository typeofPermisionWriteRepository;

        public TypeofPermissionCreateCommandHandler(IMapper mapper,ITypeofPermisionWriteRepository typeofPermisionWriteRepository)
        {
            this.mapper = mapper;
            this.typeofPermisionWriteRepository = typeofPermisionWriteRepository;
        }
        public async Task<TypeofPermissionCreateCommandResponse> Handle(TypeofPermissionCreateCommand request, CancellationToken cancellationToken)
        {
            var typeofPermission = mapper.Map<TypeofPermission>(request);
            bool success = await typeofPermisionWriteRepository.AddAsync(typeofPermission, cancellationToken);
            await typeofPermisionWriteRepository.SaveAsync(cancellationToken);

            TypeofPermissionCreateCommandResponse responce = new TypeofPermissionCreateCommandResponse
            {
                Response = request,
                Success = success,
                Message = success ? "İşlem Başarılı" : "İşlem Başarısız"
            };
            return responce;
        }
    }
}
