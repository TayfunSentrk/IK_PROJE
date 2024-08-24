using AutoMapper;
using IKProje.Application.Contract.DepartmentRepositories;
using IKProje.Application.ViewModels;
using IKProje.Application.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetSingle
{
    public class DepartmentGetSingleQueryHandler : IRequestHandler<DepartmentGetSingleQuery, DepartmentViewModel>
    {
        private readonly IDepartmentReadRepository readRepository;
        private readonly IMapper mapper;

        public DepartmentGetSingleQueryHandler(IDepartmentReadRepository readRepository,IMapper mapper)
        {
            this.readRepository = readRepository;
            this.mapper = mapper;
        }
        public async Task<DepartmentViewModel> Handle(DepartmentGetSingleQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<DepartmentViewModel>(await readRepository.GetAsync(x => x.Id == request.Id, cancellationToken));
        }
    }
}
