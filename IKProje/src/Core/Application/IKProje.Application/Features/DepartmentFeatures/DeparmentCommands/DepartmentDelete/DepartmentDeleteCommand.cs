using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentDelete
{
    public class DepartmentDeleteCommand:IRequest<ServiceResponse<DepartmentDeleteCommand>>
    {
        public string Id { get; set; } = default!;
    }
}
