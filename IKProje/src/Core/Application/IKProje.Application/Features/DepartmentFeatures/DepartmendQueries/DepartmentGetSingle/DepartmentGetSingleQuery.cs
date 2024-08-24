using IKProje.Application.ViewModels;
using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetSingle
{
    public class DepartmentGetSingleQuery:IRequest<DepartmentViewModel>
    {
        public string Id { get; set; } = default!;

    }
}
