using IKProje.Application.ViewModels;
using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetAll
{
    public class VocationGetAllQuery:IRequest<IEnumerable<VocationViewModel>>
    {
        public bool Tracking { get; set; } = true;
    }
}
