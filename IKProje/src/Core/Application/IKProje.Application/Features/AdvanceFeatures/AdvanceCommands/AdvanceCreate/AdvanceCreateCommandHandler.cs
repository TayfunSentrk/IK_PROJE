using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.Common;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate
{
    public class AdvanceCreateCommandHandler : IRequestHandler<AdvanceCreateCommand, AdvanceCreateCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IAdvanceWriteRepository advanceWriteRepository;
        private readonly UserManager<Personel> userManager;

        public AdvanceCreateCommandHandler(IMapper mapper,IAdvanceWriteRepository advanceWriteRepository,UserManager<Personel> userManager)
        {
            this.mapper = mapper;
            this.advanceWriteRepository = advanceWriteRepository;
            this.userManager = userManager;
        }
        public async Task<AdvanceCreateCommandResponse> Handle(AdvanceCreateCommand request, CancellationToken cancellationToken)
        {
            Personel? personel = await userManager.FindByNameAsync(request.UserName!);
            Advance advance = mapper.Map<Advance>(request);
            advance.PersonelId = personel.Id;
            advance.Personel = personel;
            advance.Company = personel.Company;
            advance.CompanyId=personel.CompanyId;
            advance.Name = request.TypeofAdvance.ToString();
            bool success = await advanceWriteRepository.AddAsync(advance, cancellationToken);
            await advanceWriteRepository.SaveAsync(cancellationToken);

            AdvanceCreateCommandResponse responce = new AdvanceCreateCommandResponse
            {
                Response = request,
                Success = success,
                Message = success ? "İşlem Başarılı" : "İşlem Başarısız"
            };
            return responce;
        }
    }
}
