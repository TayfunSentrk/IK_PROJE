using AutoMapper;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;
using IKProje.Application.ViewModels;
using IKProje.Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Mapping.CompanyMappings
{
    public class CompanyMapping:Profile
    {
        public CompanyMapping()
        {

            CreateMap<Company, CompanyCreateCommand>().ReverseMap();
            CreateMap<Company, CompanyEditCommand>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<CompanyEditCommand, CompanyViewModel>().ReverseMap();
        }
    }
}
