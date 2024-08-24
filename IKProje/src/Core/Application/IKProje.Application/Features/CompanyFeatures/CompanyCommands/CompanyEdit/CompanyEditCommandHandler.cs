using AutoMapper;
using IKProje.Application.Contract.Common;
using IKProje.Application.Contract.CompanyRepositories;
using IKProje.Domain.Entities.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit
{
    public class CompanyEditCommandHandler : IRequestHandler<CompanyEditCommand, CompanyEditCommandResponse>
    {
        private readonly ICompanyWriteRepository writeRepository;
        private readonly IMapper mapper;
        private readonly ICompanyReadRepository readRepository;

        public CompanyEditCommandHandler(ICompanyWriteRepository writeRepository,IMapper mapper,ICompanyReadRepository readRepository)
        {
            this.writeRepository = writeRepository;
            this.mapper = mapper;
            this.readRepository = readRepository;
        }
        public async Task<CompanyEditCommandResponse> Handle(CompanyEditCommand request, CancellationToken cancellationToken)
        {
            var companyasd = await readRepository.GetAsync(x => x.Id == request.Id, cancellationToken);
            if (companyasd == null) throw new Exception();

            // request'teki verileri companyasd nesnesine eşle
            mapper.Map(request, companyasd);

            // Güncellenmiş companyasd nesnesini kaydet
            bool update = writeRepository.Update(companyasd, cancellationToken);
            await writeRepository.SaveAsync(cancellationToken);

            CompanyEditCommandResponse response = new CompanyEditCommandResponse()
            {
                Success = update,
                Message = update ? "İşlem başarılı" : "İşlem Başarısız",
                Response = request
            };
            return response;


        }
    }
}
