using AutoMapper;
using IKProje.Application.Contract.VocationRepositories;
using IKProje.Application.Wrapper;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.VocationFeatures.VocationCommands.VocationCrreate
{
    public class VocationCreateCommandHandler : IRequestHandler<VocationCreateCommand, ServiceResponse<VocationCreateCommand>>
    {
        private readonly IVocationWriteRepository writeRepository;
        private readonly IMapper mapper;

        public VocationCreateCommandHandler(IVocationWriteRepository writeRepository,IMapper mapper)
        {
            this.writeRepository = writeRepository;
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<VocationCreateCommand>> Handle(VocationCreateCommand request, CancellationToken cancellationToken)
        {
            Vocation? vocation = mapper.Map<Vocation>(request);
          bool result=  await writeRepository.AddAsync(vocation,cancellationToken);
            await writeRepository.SaveAsync(cancellationToken);
            ServiceResponse<VocationCreateCommand> response = new ServiceResponse<VocationCreateCommand>(request)
            {
                IsSuccsess=result,
                Message=result ? "İşlem Başarılı":"İşlem Başarısız"
            };
            return response;

        }
    }
}
