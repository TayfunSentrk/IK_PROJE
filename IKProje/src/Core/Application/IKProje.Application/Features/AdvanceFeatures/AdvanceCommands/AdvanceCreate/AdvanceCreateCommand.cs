using IKProje.Application.ViewModels;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate
{
    public class AdvanceCreateCommand:IRequest<AdvanceCreateCommandResponse>
    {
        
     
        public decimal TotalAmount { get; set; }
        public Currency Currency { get; set; }
        public TypeofAdvance TypeofAdvance { get; set; }
        public string Description { get; set; }
        public string? UserName { get; set; }
        public string? CompanyId { get; set; } //++
        public CompanyViewModel? CompanyViewModel { get; set; }
    }
}
