using IKProje.Application.ViewModels;
using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetAll
{
    public class DepartmentGetAllQuery:IRequest<IEnumerable<DepartmentViewModel>>
    {
        public bool Tracking { get; set; } = true;
    }
}
