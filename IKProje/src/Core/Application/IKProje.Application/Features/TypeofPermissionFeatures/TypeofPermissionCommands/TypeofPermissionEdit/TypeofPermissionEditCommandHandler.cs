using AutoMapper;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Contract.TypeofPermissionRepository;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionEdit
{
    public class TypeofPermissionEditCommandHandler : IRequestHandler<TypeofPermissionEditCommand, TypeofPermissionEditCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ITypeofPermisionWriteRepository typeofPermisionWriteRepository;
        private readonly ITypeofPermissionReadRepository typeofPermissionReadRepository;

        public TypeofPermissionEditCommandHandler(IMapper mapper, ITypeofPermisionWriteRepository typeofPermisionWriteRepository,ITypeofPermissionReadRepository typeofPermissionReadRepository)
        {
            this.mapper = mapper;
            this.typeofPermisionWriteRepository = typeofPermisionWriteRepository;
            this.typeofPermissionReadRepository = typeofPermissionReadRepository;
        }
        public async Task<TypeofPermissionEditCommandResponse> Handle(TypeofPermissionEditCommand request, CancellationToken cancellationToken)
        {
            //TypeofPermission? update = await typeofPermissionReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            //if (update == null) throw new Exception("Güncellenecek öğe Bulunamadı");


            //TypeofPermission? typeofPermission = mapper.Map<TypeofPermission>(request);
            //typeofPermission.LastUpdatedTime = DateTime.Now;
            //bool IsUpdate = typeofPermisionWriteRepository.Update(typeofPermission, cancellationToken);
            //await typeofPermisionWriteRepository.SaveAsync(cancellationToken);
            //TypeofPermissionEditCommandResponse response = new TypeofPermissionEditCommandResponse
            //{
            //    Success = IsUpdate,
            //    Message = IsUpdate ? "İşlem başarılı" : "İşlem Başarısız",

            //};
            //return response;


            TypeofPermission? update = await typeofPermissionReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (update == null) throw new Exception("Güncellenecek öğe Bulunamadı");

            // AutoMapper kullanarak mevcut varlık üzerinde güncelleme yapın
            mapper.Map(request, update);
            update.LastUpdatedTime = DateTime.Now;

            // Güncellemeyi kaydedin
            bool IsUpdate = typeofPermisionWriteRepository.Update(update, cancellationToken);
            await typeofPermisionWriteRepository.SaveAsync(cancellationToken);

            TypeofPermissionEditCommandResponse response = new TypeofPermissionEditCommandResponse
            {
                Success = IsUpdate,
                Message = IsUpdate ? "İşlem başarılı" : "İşlem Başarısız",
            };

            return response;
        }
    }
}
