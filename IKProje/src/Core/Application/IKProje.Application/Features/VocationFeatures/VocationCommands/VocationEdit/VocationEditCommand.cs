using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.VocationFeatures.VocationCommands.VocationEdit
{
    public class VocationEditCommand:IRequest<ServiceResponse<VocationEditCommand>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
