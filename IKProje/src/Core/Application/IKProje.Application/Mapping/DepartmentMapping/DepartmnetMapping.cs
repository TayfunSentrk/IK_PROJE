using AutoMapper;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentCreate;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentEdit;
using IKProje.Application.ViewModels;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Mapping.DepartmentMapping
{
    public class DepartmnetMapping:Profile
    {
        public DepartmnetMapping()
        {
            CreateMap<Department,DepartmentCreateCommand>().ReverseMap();
            CreateMap<Department,DepartmentEditCommand>().ReverseMap();
            CreateMap<Department,DepartmentViewModel>().ReverseMap();
            CreateMap<DepartmentEditCommand,DepartmentViewModel>().ReverseMap();
            
        }
    }
}
