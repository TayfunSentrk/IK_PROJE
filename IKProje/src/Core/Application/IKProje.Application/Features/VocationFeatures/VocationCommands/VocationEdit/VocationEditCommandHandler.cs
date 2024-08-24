using AutoMapper;
using IKProje.Application.Contract.VocationRepositories;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentEdit;
using IKProje.Application.Wrapper;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.VocationFeatures.VocationCommands.VocationEdit
{
    public class VocationEditCommandHandler : IRequestHandler<VocationEditCommand, ServiceResponse<VocationEditCommand>>
    {
        private readonly IVocationReadRepository readRepository;
        private readonly IVocationWriteRepository writeRepository;
        private readonly IMapper mapper;

        public VocationEditCommandHandler(IVocationReadRepository readRepository,IVocationWriteRepository writeRepository,IMapper mapper)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<VocationEditCommand>> Handle(VocationEditCommand request, CancellationToken cancellationToken)
        {
            Vocation? vocationUpdate = await readRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (vocationUpdate == null) throw new Exception("Güncellenecek öğe Bulunamadı");

            // vocationUpdate nesnesini güncelleyin
            mapper.Map(request, vocationUpdate);

            bool update = writeRepository.Update(vocationUpdate, cancellationToken);
            await writeRepository.SaveAsync(cancellationToken);

            ServiceResponse<VocationEditCommand> response = new ServiceResponse<VocationEditCommand>(request)
            {
                IsSuccsess = update,
                Message = update ? "İşlem başarılı" : "İşlem Başarısız",
            };

            return response;
        }
    }
}
