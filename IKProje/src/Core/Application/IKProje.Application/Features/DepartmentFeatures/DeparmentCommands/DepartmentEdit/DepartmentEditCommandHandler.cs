using AutoMapper;
using IKProje.Application.Contract.Common;
using IKProje.Application.Contract.DepartmentRepositories;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;
using IKProje.Application.Wrapper;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentEdit
{
    public class DepartmentEditCommandHandler : IRequestHandler<DepartmentEditCommand, ServiceResponse<DepartmentEditCommand>>
    {
        private readonly IDepartmentReadRepository readRepository;
        private readonly IMapper mapper;
        private readonly IDepartmentWriteRepository writeRepository;

        public DepartmentEditCommandHandler(IDepartmentReadRepository readRepository,IMapper mapper,IDepartmentWriteRepository writeRepository)
        {
            this.readRepository = readRepository;
            this.mapper = mapper;
            this.writeRepository = writeRepository;
        }
        public async Task<ServiceResponse<DepartmentEditCommand>> Handle(DepartmentEditCommand request, CancellationToken cancellationToken)
        {

            Department? departmentUpdate = await readRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (departmentUpdate == null) throw new Exception("Güncellenecek öğe Bulunamadı");

            // Mevcut nesneyi güncelleyin
            mapper.Map(request, departmentUpdate);
            departmentUpdate.LastUpdatedTime = DateTime.Now;

            bool update = writeRepository.Update(departmentUpdate, cancellationToken);
            await writeRepository.SaveAsync(cancellationToken);

            ServiceResponse<DepartmentEditCommand> response = new ServiceResponse<DepartmentEditCommand>(request)
            {
                IsSuccsess = update,
                Message = update ? "İşlem başarılı" : "İşlem Başarısız",
            };

            return response;



        }
    }
}
