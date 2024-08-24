using IKProje.Application.Contract.DepartmentRepositories;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyDelete;
using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentDelete
{
    public class DepartmentDeleteCommandHandler : IRequestHandler<DepartmentDeleteCommand, ServiceResponse<DepartmentDeleteCommand>>
    {
        private readonly IDepartmentWriteRepository writeRepository;

        public DepartmentDeleteCommandHandler(IDepartmentWriteRepository writeRepository)
        {
            this.writeRepository = writeRepository;
        }
        public async Task<ServiceResponse<DepartmentDeleteCommand>> Handle(DepartmentDeleteCommand request, CancellationToken cancellationToken)
        {
            bool result= writeRepository.RemoveById( request.Id,cancellationToken);
            await writeRepository.SaveAsync(cancellationToken);

            ServiceResponse<DepartmentDeleteCommand> responce = new ServiceResponse<DepartmentDeleteCommand>(request)
            {
                IsSuccsess=result,
                Message = result ? "İşlem Başarılı" : "İşlem Başarısız"
            };

            return responce;
        }
    }
}
