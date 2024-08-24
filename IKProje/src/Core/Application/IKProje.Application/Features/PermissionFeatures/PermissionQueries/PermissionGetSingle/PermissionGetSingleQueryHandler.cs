using AutoMapper;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Application.ViewModels.PermissionViewModels;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingle
{
    public class PermissionGetSingleQueryHandler : IRequestHandler<PermissionGetSingleQuery, PermissionViewModel>
    {
        private readonly IMapper mapper;
        private readonly IPermissionReadRepository permissionReadRepository;

        public PermissionGetSingleQueryHandler(IMapper mapper, IPermissionReadRepository permissionReadRepository)
        {
            this.mapper = mapper;
            this.permissionReadRepository = permissionReadRepository;
        }

        

        public async Task<PermissionViewModel> Handle(PermissionGetSingleQuery request, CancellationToken cancellationToken)
        {

            if (request.IsApproval)
            {
                return mapper.Map<PermissionViewModel>(await permissionReadRepository.GetSingleInclude(x => x.Id == request.Id, include: query => query.Include(u => u.TypeofPermission).Include(p => p.Personel), cancellationToken));
            }

            return mapper.Map<PermissionViewModel>(await permissionReadRepository.GetSingleInclude(f => f.Id == request.Id, include: query => query.Include(u => u.TypeofPermission), cancellationToken));

        }
    }
}
