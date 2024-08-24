using AutoMapper;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleCommands.RoleCreate
{
    public class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, IdentityResult>
    {
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;

        public RoleCreateCommandHandler(RoleManager<Role> roleManager,IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }
        public async Task<IdentityResult> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
        {
            var role = mapper.Map<Role>(request);
            return await roleManager.CreateAsync(role);
        }
    }
}
