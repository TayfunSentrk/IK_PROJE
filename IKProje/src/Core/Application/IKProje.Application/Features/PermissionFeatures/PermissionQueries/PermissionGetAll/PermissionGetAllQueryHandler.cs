using AutoMapper;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Application.ViewModels.PermissionViewModels;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetAll
{
    public class PermissionGetAllQueryHandler : IRequestHandler<PermissionGetAllQuery, IEnumerable<PermissionViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IPermissionReadRepository permissionReadRepository;
        private readonly UserManager<Personel> userManager;

        public PermissionGetAllQueryHandler(IMapper mapper, IPermissionReadRepository permissionReadRepository, UserManager<Personel> userManager = null)
        {
            this.mapper = mapper;
            this.permissionReadRepository = permissionReadRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<PermissionViewModel>> Handle(PermissionGetAllQuery request, CancellationToken cancellationToken)
        {
           


              //include yazıcak ve include halini
                var personel = await userManager.FindByNameAsync(request.UserName);

                

                if (request.IsApproval)
                {
       
               
                    return mapper.Map<IEnumerable<PermissionViewModel>>(await permissionReadRepository.GetAllInclude(f => f.CompanyId == personel.CompanyId, include: query => query.Include(u => u.TypeofPermission).Include(p=>p.Personel), cancellationToken));
                }

                return mapper.Map<IEnumerable<PermissionViewModel>>(await permissionReadRepository.GetAllInclude(f => f.PersonelId == personel.Id, include: query => query.Include(u => u.TypeofPermission), cancellationToken));
            


        }
    }
}
