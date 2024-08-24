using IKProje.Application.Contract.VocationRepositories;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentDelete;
using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.VocationFeatures.VocationCommands.VocationDelete
{
    public class VocationDeleteCommandHandler : IRequestHandler<VocationDeleteCommand, ServiceResponse<VocationDeleteCommand>>
    {
        private readonly IVocationWriteRepository writeRepository;

        public VocationDeleteCommandHandler(IVocationWriteRepository writeRepository)
        {
            this.writeRepository = writeRepository;
        }
        public async Task<ServiceResponse<VocationDeleteCommand>> Handle(VocationDeleteCommand request, CancellationToken cancellationToken)
        {
            bool result = writeRepository.RemoveById(request.Id, cancellationToken);
            await writeRepository.SaveAsync(cancellationToken);

            ServiceResponse<VocationDeleteCommand> responce = new ServiceResponse<VocationDeleteCommand>(request)
            {
                IsSuccsess = result,
                Message = result ? "İşlem Başarılı" : "İşlem Başarısız"
            };

            return responce;
        }
    }
}
