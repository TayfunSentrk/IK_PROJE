using AutoMapper;
using IKProje.Application.Features.RoleFeatures.RoleCommands.RoleCreate;
using IKProje.Application.Features.RoleFeatures.RoleCommands.RoleEdit;
using IKProje.Application.ViewModels.Roles;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Mapping.RoleMappings
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<Role, RoleCreateCommand>().ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();
            CreateMap<Role, UpdateRoleViewModel>().ReverseMap();
            CreateMap<RoleEditCommand, UpdateRoleViewModel>().ReverseMap();
            CreateMap<Role, AssignRoleToUserViewModel>().ReverseMap();

        }
    }
}
