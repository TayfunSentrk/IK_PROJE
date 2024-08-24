using IKProje.Application.ViewModels;
using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetSingle
{
    public class VocationGetSingleQuery:IRequest<VocationViewModel>
    {
        public string Id { get; set; } = default!;
    }
}
