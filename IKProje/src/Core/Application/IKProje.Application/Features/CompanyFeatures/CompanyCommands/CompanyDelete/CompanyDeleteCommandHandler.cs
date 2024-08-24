using IKProje.Application.Contract.CompanyRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyDelete
{
    public class CompanyDeleteCommandHandler : IRequestHandler<CompanyDeleteCommand, CompanyDeleteCommandResponse>
    {
        private readonly ICompanyWriteRepository writeRepository;

        public CompanyDeleteCommandHandler(ICompanyWriteRepository writeRepository)
        {
            this.writeRepository = writeRepository;
        }
        public async Task<CompanyDeleteCommandResponse> Handle(CompanyDeleteCommand request, CancellationToken cancellationToken)
        {
            bool success =  writeRepository.RemoveById(request.Id, cancellationToken);
            await writeRepository.SaveAsync(cancellationToken);
            CompanyDeleteCommandResponse responce = new CompanyDeleteCommandResponse
            {
                Success = success,
                Message = success ? "İşlem Başarılı" : "İşlem Başarısız"
            };
        

            return responce;
        }
    }
}
