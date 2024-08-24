using AutoMapper;
using IKProje.Application.Contract.CompanyRepositories;
using IKProje.Application.Contract.DepartmentRepositories;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentCreate
{
    public class DepartmentCreateCommandHandler : IRequestHandler<DepartmentCreateCommand, DepartmentCreateCommandResponse>
    {
        private readonly IDepartmentWriteRepository writeRepository;
        private readonly IMapper mapper;
        private readonly UserManager<Personel> userManger;

        public DepartmentCreateCommandHandler(IDepartmentWriteRepository writeRepository, IMapper mapper,UserManager<Personel> userManger)
        {
            this.writeRepository = writeRepository;
            this.mapper = mapper;
            this.userManger = userManger;
        }
        public async Task<DepartmentCreateCommandResponse> Handle(DepartmentCreateCommand request, CancellationToken cancellationToken)
        {
            var department = mapper.Map<Department>(request);
            var currentUser=await userManger.FindByNameAsync(request.UserName);
            department.Şiketler.Add( new DepartmentCompany
            {
                CompanyId = currentUser.CompanyId,
                DepartmanId = department.Id,
                Department=department,
                Company=currentUser.Company
            });
            bool success = await writeRepository.AddAsync(department, cancellationToken);
            await writeRepository.SaveAsync(cancellationToken);

            DepartmentCreateCommandResponse responce = new DepartmentCreateCommandResponse
            {
                Response = request,
                Success = success,
                Message = success ? "İşlem Başarılı" : "İşlem Başarısız"
            };
            return responce;
        }
    }
}
