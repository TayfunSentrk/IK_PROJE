using AutoMapper;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Contract.TypeofPermissionRepository;
using IKProje.Application.ViewModels.PermissionViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetAll
{
    public class TypeofPermissionGetAllQueryHandler : IRequestHandler<TypeofPermissionGetAllQuery, IEnumerable<TypeofPermissionViewModel>>
    {
        private readonly IMapper mapper;
        private readonly ITypeofPermissionReadRepository typeofPermissionReadRepository;
        private readonly UserManager<Personel> userManager;

        public TypeofPermissionGetAllQueryHandler(IMapper mapper,ITypeofPermissionReadRepository typeofPermissionReadRepository,UserManager<Personel> userManager)
        {
            this.mapper = mapper;
            this.typeofPermissionReadRepository = typeofPermissionReadRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<TypeofPermissionViewModel>> Handle(TypeofPermissionGetAllQuery request, CancellationToken cancellationToken)
        {
            if (request.UserName != null)
            {
                var currentUser=await userManager.FindByNameAsync(request.UserName);
                return mapper.Map<IEnumerable<TypeofPermissionViewModel>>(await typeofPermissionReadRepository.GetAllAsync(x=>x.Gender==currentUser.Gender,cancellationToken, request.Tracking));

            }
            return mapper.Map<IEnumerable<TypeofPermissionViewModel>>(await typeofPermissionReadRepository.GetAllAsync(cancellationToken, request.Tracking));
        }
    }
}
