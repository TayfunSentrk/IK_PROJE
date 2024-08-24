using AutoMapper;
using IKProje.Application.Contract.CompanyRepositories;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate
{
    public class CompanyCreateCommandHandler : IRequestHandler<CompanyCreateCommand, CompanyCreateCommandResponse>
    {
        private readonly ICompanyWriteRepository writeRepository;
        private readonly IMapper mapper;

        public CompanyCreateCommandHandler(ICompanyWriteRepository writeRepository,IMapper mapper)
        {
            this.writeRepository = writeRepository;
            this.mapper = mapper;
        }
        public async Task<CompanyCreateCommandResponse> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
        {
            var company = mapper.Map<Company>(request);
            bool success = await writeRepository.AddAsync(company,cancellationToken);
            await writeRepository.SaveAsync(cancellationToken);
           
            CompanyCreateCommandResponse responce= new CompanyCreateCommandResponse
            {
                Response=request,
                Success=success,
                Message=success?"İşlem Başarılı":"İşlem Başarısız"
            };
            return responce;
        }
    }
}
