using AutoMapper;
using IKProje.Application.Contract.PermissionRepository;
using IKProje.Application.ViewModels.PermissionViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingleForEdit
{
    public class PermissonGetSingleForEditCommandHandler : IRequestHandler<PermissonGetSingleForEditCommand, PermissonViewForEdit>
    {

        private readonly IMapper mapper;
        private readonly IPermissionReadRepository permissionReadRepository;

        public PermissonGetSingleForEditCommandHandler(IMapper mapper, IPermissionReadRepository permissionReadRepository)
        {
            this.mapper = mapper;
            this.permissionReadRepository = permissionReadRepository;
        }

        public async Task<PermissonViewForEdit> Handle(PermissonGetSingleForEditCommand request, CancellationToken cancellationToken)
        {
           

            return mapper.Map<PermissonViewForEdit>(await permissionReadRepository.GetAsync(x=>x.Id==request.Id,cancellationToken,request.IsTracking));
        }
    }
}
