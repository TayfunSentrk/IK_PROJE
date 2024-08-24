using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentEdit
{
    public class DepartmentEditCommand:IRequest<ServiceResponse<DepartmentEditCommand>>
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
