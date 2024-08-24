using AutoMapper;
using IKProje.Application.Features.VocationFeatures.VocationCommands.VocationCrreate;
using IKProje.Application.Features.VocationFeatures.VocationCommands.VocationEdit;
using IKProje.Application.ViewModels;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Mapping.VocationMappings
{
    public class VocationMapping:Profile
    {
        public VocationMapping()
        {
            CreateMap<Vocation,VocationCreateCommand>().ReverseMap();
            CreateMap<Vocation,VocationEditCommand>().ReverseMap();
            CreateMap<Vocation,VocationViewModel>().ReverseMap();
            CreateMap<VocationEditCommand,VocationViewModel>().ReverseMap();
        }

    }
}
