using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.Common;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.ViewModels;
using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetAll
{
    public class AdvanceGetAllQueryHandler : IRequestHandler<AdvanceGetAllQuery, IEnumerable<AdvanceViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IAdvanceReadRepository advanceReadRepository;

        private readonly UserManager<Personel> user;

        public AdvanceGetAllQueryHandler(IMapper mapper, IAdvanceReadRepository advanceReadRepository, UserManager<Personel> user)
        {
            this.mapper = mapper;
            this.advanceReadRepository = advanceReadRepository;
            this.user = user;
        }
        public async Task<IEnumerable<AdvanceViewModel>> Handle(AdvanceGetAllQuery request, CancellationToken cancellationToken)
        {   

               

            //include yazıcak ve include halini
            var personel = await user.FindByNameAsync(request.UserName);

            if (request.IsApproval)
            {
                return mapper.Map<IEnumerable<AdvanceViewModel>>(await advanceReadRepository.GetAllInclude(f => f.CompanyId == personel.CompanyId, include: query => query.Include(p => p.Personel), cancellationToken));
            }
            return mapper.Map<IEnumerable<AdvanceViewModel>>(await advanceReadRepository.GetAllAsync(f => f.PersonelId == personel.Id, cancellationToken, request.Tracking));

        }
    }
}
