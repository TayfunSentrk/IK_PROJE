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

namespace IKProje.Application.Features.RoleFeatures.RoleCommands.RoleAssign
{
    public class RoleAssignCommandHandler : IRequestHandler<RoleAssignCommand, List<AssignRoleToUserViewModel>>
    {
        private readonly UserManager<Personel> userManager;
        private readonly IMapper mapper;

        public RoleAssignCommandHandler(UserManager<Personel> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<List<AssignRoleToUserViewModel>> Handle(RoleAssignCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByIdAsync(request.UserId);
            foreach (var role in request.Roles)
            {
                if (role.Exist)
                {
                    await userManager.AddToRoleAsync(currentUser, role.Name);
                }
                else
                {
                    await userManager.RemoveFromRoleAsync(currentUser, role.Name);
                }

            }
            return request.Roles;
            
        }
    }
}
