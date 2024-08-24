using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyDelete
{
    public class CompanyDeleteCommand:IRequest<CompanyDeleteCommandResponse>
    {
        public string Id { get; set; }= default!;
    }
}
