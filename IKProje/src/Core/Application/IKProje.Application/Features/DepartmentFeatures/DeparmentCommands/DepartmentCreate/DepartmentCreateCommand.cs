using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentCreate
{
    public class DepartmentCreateCommand:IRequest<DepartmentCreateCommandResponse>
    {
        public string? UserName { get; set; } 
        public string Name { get; set; } = default!;
    }
}
