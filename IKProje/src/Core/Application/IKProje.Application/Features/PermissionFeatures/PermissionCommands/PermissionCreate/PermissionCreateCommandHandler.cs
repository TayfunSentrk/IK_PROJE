using AutoMapper;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Contract.TypeofPermissionRepository;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate
{
    public class PermissionCreateCommandHandler : IRequestHandler<PermissionCreateCommand, PermissionCreateCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IPermissionWriteRepository permissionWriteRepository;
        private readonly UserManager<Personel> userManager;
        private readonly ITypeofPermissionReadRepository typeofPermissionReadRepository;


        public PermissionCreateCommandHandler(IMapper mapper,IPermissionWriteRepository permissionWriteRepository,UserManager<Personel> userManager,ITypeofPermissionReadRepository typeofPermissionReadRepository)
        {
            this.mapper = mapper;
            this.permissionWriteRepository = permissionWriteRepository;
            this.userManager = userManager;
            this.typeofPermissionReadRepository = typeofPermissionReadRepository;
        }
        public async Task<PermissionCreateCommandResponse> Handle(PermissionCreateCommand request, CancellationToken cancellationToken)
        {
            Personel? personel = await userManager.FindByNameAsync(request.UserName!);

            TypeofPermission typeofPermission = await typeofPermissionReadRepository.GetAsync(x => x.Id == request.TypeofPermissionId);
            
            var permission = mapper.Map<Permission>(request);
            permission.DayCount = typeofPermission.Duration;
            permission.FinishedDate = permission.StartedDate.AddDays(permission.DayCount);
            permission.Name = typeofPermission.Name;
            permission.PersonelId = personel.Id;
            permission.Personel= personel;
            permission.TypeofPermission = typeofPermission;
            permission.TypeofPermissionId = typeofPermission.Id;
            permission.Company = personel.Company;
            permission.CompanyId = personel.CompanyId;
            permission.CreatedTime=DateTime.UtcNow;
            bool success = await permissionWriteRepository.AddAsync(permission, cancellationToken);
            await permissionWriteRepository.SaveAsync(cancellationToken);

            PermissionCreateCommandResponse responce = new PermissionCreateCommandResponse
            {
                Response = request,
                Success = success,
                Message = success ? "İşlem Başarılı" : "İşlem Başarısız"
            };
            return responce;
        }
    }
}
