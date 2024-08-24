using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleCommands.RoleRemove
{
    public class RoleRemoveCommandHandler : IRequestHandler<RoleRemoveCommand, IdentityResult>
    {
        private readonly RoleManager<Role> roleManager;

        public RoleRemoveCommandHandler(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IdentityResult> Handle(RoleRemoveCommand request, CancellationToken cancellationToken)
        {
            Role? roleToRemove = await roleManager.FindByIdAsync(request.Id);
            if (roleToRemove == null)
                throw new Exception($"Role {request.Id} does not exist");
            IdentityResult deleteRole = await roleManager.DeleteAsync(roleToRemove);
            return deleteRole;
        }
    }
}
