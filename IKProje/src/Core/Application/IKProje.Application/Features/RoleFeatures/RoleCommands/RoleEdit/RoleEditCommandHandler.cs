using AutoMapper;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleCommands.RoleEdit
{
    public class RoleEditCommandHandler : IRequestHandler<RoleEditCommand, IdentityResult>
    {
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;

        public RoleEditCommandHandler(RoleManager<Role> roleManager,IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }
        public async Task<IdentityResult> Handle(RoleEditCommand request, CancellationToken cancellationToken)
        {
            Role? roleToUpdate = await roleManager.FindByIdAsync(request.Id);
            if (roleToUpdate == null)
                throw new Exception("Güncellenecek role bulunamamıştır.");
            roleToUpdate.Name = request.Name;
            IdentityResult? result = await roleManager.UpdateAsync(roleToUpdate);
            return result;
        }
    }
}
