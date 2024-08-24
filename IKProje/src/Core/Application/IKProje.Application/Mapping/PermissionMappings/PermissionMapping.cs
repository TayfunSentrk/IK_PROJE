using AutoMapper;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionApproval;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit;
using IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingleForEdit;
using IKProje.Application.ViewModels.PermissionViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Mapping.PermissionMappings
{
    public class PermissionMapping:Profile
    {
        public PermissionMapping()
        {
            CreateMap<Permission, PermissionViewModel>().ReverseMap();
            CreateMap<Permission, PermissionCreateCommand>().ReverseMap();
            CreateMap<Permission, PermissionEditCommand>().ReverseMap();
            CreateMap<PermissonViewForEdit, PermissionEditCommand>().ReverseMap();
            CreateMap<PermissionViewModel, PermissionApprovalCommand>().ReverseMap();
            CreateMap<Permission,PermissonViewForEdit>().ReverseMap();
        }
    }
}
