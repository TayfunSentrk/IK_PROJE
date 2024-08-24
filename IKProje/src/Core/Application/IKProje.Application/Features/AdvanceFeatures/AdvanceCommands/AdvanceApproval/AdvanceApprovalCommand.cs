using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval
{
    public class AdvanceApprovalCommand:IRequest<AdvanceApprovalCommandResponse>
    {
        public string Id { get; set; }
        public Approval StatusofApproval { get; set; }
        public string PersonelId { get; set; }
        public string PersonelName {  get; set; }
    }
}
