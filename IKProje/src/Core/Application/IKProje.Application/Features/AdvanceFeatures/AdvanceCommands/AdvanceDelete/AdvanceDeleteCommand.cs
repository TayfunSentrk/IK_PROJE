using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceDelete
{
    public class AdvanceDeleteCommand:IRequest<AdvanceDeleteCommandResponse>
    {
        public string Id { get; set; }
    }
}
