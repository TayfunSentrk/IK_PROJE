using AutoMapper;
using IKProje.Application.ViewModels.Roles;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleQueries.RoleGetAll
{
    public class RoleGetAllQueryHandler : IRequestHandler<RoleGetAllQuery, IEnumerable<RoleViewModel>>
    {
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;

        public RoleGetAllQueryHandler(RoleManager<Role> roleManager,IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<RoleViewModel>> Handle(RoleGetAllQuery request, CancellationToken cancellationToken)
        {
           return mapper.Map<IEnumerable<RoleViewModel>>(await roleManager.Roles.ToListAsync());
        }
    }
}
