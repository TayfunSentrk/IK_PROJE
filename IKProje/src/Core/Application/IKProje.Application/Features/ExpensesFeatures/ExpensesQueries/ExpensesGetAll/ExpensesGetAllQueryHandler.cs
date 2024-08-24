using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.ExpensesRepository;
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

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetAll
{
    public class ExpensesGetAllQueryHandler : IRequestHandler<ExpensesGetAlllQuery, IEnumerable<ExpensesViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IExpensesReadRepository expensesReadRepository;
        private readonly UserManager<Personel> userManager;

        public ExpensesGetAllQueryHandler(IMapper mapper,IExpensesReadRepository expensesReadRepository,UserManager<Personel> userManager)
        {
            this.mapper = mapper;
            this.expensesReadRepository = expensesReadRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<ExpensesViewModel>> Handle(ExpensesGetAlllQuery request, CancellationToken cancellationToken)
        {
          
            
                //include yazıcak ve include halini
                var personel = await userManager.FindByNameAsync(request.UserName);

                if (request.IsApproval)
                {
                    return mapper.Map<IEnumerable<ExpensesViewModel>>(await expensesReadRepository.GetAllInclude(f => f.CompanyId == personel.CompanyId, include: query => query.Include(p => p.Personel), cancellationToken));
                }
                return mapper.Map<IEnumerable<ExpensesViewModel>>(await expensesReadRepository.GetAllAsync(f => f.PersonelId == personel.Id, cancellationToken, request.Tracking));
            


        }
    }
}
