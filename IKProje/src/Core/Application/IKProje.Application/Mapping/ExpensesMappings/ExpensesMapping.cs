using AutoMapper;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesApproval;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesEdit;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingleForEdit;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Mapping.ExpensesMappings
{
    public class ExpensesMapping:Profile
    {
        public ExpensesMapping()
        {

            CreateMap<Expenses, ExpensesViewModel>().ReverseMap();
            CreateMap<Expenses, ExpensesCreateCommand>().ReverseMap();
            CreateMap<Expenses, ExpensesEditCommand>().ReverseMap();
            CreateMap<ExpensesViewForEdit, ExpensesEditCommand>().ReverseMap();
            CreateMap<ExpensesViewModel, ExpensesApprovalCommand>().ReverseMap();
            CreateMap<Expenses, ExpensesViewForEdit>().ReverseMap();
           
        }
    }
}
