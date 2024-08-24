using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.VocationFeatures.VocationCommands.VocationCrreate
{
    public class VocationCreateCommand:IRequest<ServiceResponse<VocationCreateCommand>>
    {
        public string Name { get; set; }
    }
}
