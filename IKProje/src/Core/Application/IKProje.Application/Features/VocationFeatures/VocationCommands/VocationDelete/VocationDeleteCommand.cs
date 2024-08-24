using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.VocationFeatures.VocationCommands.VocationDelete
{
    public class VocationDeleteCommand:IRequest<ServiceResponse<VocationDeleteCommand>>
    {
        public string Id { get; set; }
    }
}
