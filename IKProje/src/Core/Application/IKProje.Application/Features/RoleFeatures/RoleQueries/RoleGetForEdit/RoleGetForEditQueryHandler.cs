using AutoMapper;
using IKProje.Application.ViewModels.Roles;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleQueries.RoleGetForEdit
{
    public class RoleGetForEditQueryHandler : IRequestHandler<RoleGetForEditQuery, UpdateRoleViewModel>
    {
        private readonly IMapper mapper;
        private readonly RoleManager<Role> roleManager;

        public RoleGetForEditQueryHandler(IMapper mapper,RoleManager<Role> roleManager)
        {
            this.mapper = mapper;
            this.roleManager = roleManager;
        }
        public async Task<UpdateRoleViewModel> Handle(RoleGetForEditQuery request, CancellationToken cancellationToken)
        {
            Role roleUpdate = await roleManager.FindByIdAsync(request.Id);
            if (roleUpdate == null) throw new Exception("Güncellenecek role bulunamamıştır.");
            UpdateRoleViewModel updateRole=mapper.Map<UpdateRoleViewModel>(roleUpdate);
            return updateRole;

        }
    }
}
