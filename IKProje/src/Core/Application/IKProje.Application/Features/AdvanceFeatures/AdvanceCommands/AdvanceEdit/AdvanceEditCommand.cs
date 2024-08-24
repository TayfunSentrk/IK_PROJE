using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit
{
    public class AdvanceEditCommand:IRequest<AdvanceEditCommandResponse>
    {
        public string Id { get; set; } 
             
        public decimal TotalAmount { get; set; }
        public Currency Currency { get; set; }
        public TypeofAdvance TypeofAdvance { get; set; }
        public string Description { get; set; }
       
    }
}
