using AutoMapper;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.Contract.TypeofPermissionRepository;
using IKProje.Application.ViewModels.PermissionViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetSingle
{
    public class TypeofPermissionGetSingleQueryHandler : IRequestHandler<TypeofPermissionGetSingleQuery, TypeofPermissionViewModel>
    {
        private readonly IMapper mapper;
        private readonly ITypeofPermissionReadRepository typeofPermissionReadRepository;

        public TypeofPermissionGetSingleQueryHandler(IMapper mapper, ITypeofPermissionReadRepository typeofPermissionReadRepository)
        {
            this.mapper = mapper;
            this.typeofPermissionReadRepository = typeofPermissionReadRepository;
        }
        public async Task<TypeofPermissionViewModel> Handle(TypeofPermissionGetSingleQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<TypeofPermissionViewModel>(await typeofPermissionReadRepository.GetAsync(x => x.Id == request.Id, cancellationToken));
        }
    }
}
