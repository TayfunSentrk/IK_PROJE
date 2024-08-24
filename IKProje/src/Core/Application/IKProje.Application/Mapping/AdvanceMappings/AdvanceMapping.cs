using AutoMapper;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingleForEdit;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingleForEdit;
using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Mapping.AdvanceMappings
{
    public class AdvanceMapping:Profile
    {
        public AdvanceMapping()
        {
            CreateMap<Advance, AdvanceViewModel>().ReverseMap();
            CreateMap<Advance, AdvanceCreateCommand>().ReverseMap();
            CreateMap<Advance, AdvanceEditCommand>().ReverseMap();
            CreateMap<AdvanceViewForEdit, AdvanceEditCommand>().ReverseMap();
            CreateMap<AdvanceViewModel, AdvanceApprovalCommand>().ReverseMap();
            CreateMap<Advance, AdvanceViewForEdit>().ReverseMap();
        }
    }
}
