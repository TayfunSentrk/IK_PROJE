using AutoMapper;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionCreate;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionEdit;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Mapping.TypeofPermissionMappings
{
    public class TypeofPermissionMapping:Profile
    {
        public TypeofPermissionMapping()
        {
            CreateMap<TypeofPermission,TypeofPermissionViewModel>().ReverseMap();
            CreateMap<TypeofPermission,TypeofPermissionCreateCommand>().ReverseMap();
            CreateMap<TypeofPermission,TypeofPermissionEditCommand>().ReverseMap();
            CreateMap<TypeofPermissionViewModel,TypeofPermissionEditCommand>().ReverseMap();
        }
    }
}
