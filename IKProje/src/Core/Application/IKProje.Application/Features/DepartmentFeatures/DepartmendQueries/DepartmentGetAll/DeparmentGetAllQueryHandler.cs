using AutoMapper;
using IKProje.Application.Contract.DepartmentRepositories;
using IKProje.Application.ViewModels;
using IKProje.Application.Wrapper;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetAll
{
    public class DeparmentGetAllQueryHandler : IRequestHandler<DepartmentGetAllQuery, IEnumerable<DepartmentViewModel>>
    {
        private readonly IDepartmentReadRepository readRepository;
        private readonly IMapper mapper;

        public DeparmentGetAllQueryHandler(IDepartmentReadRepository readRepository,IMapper mapper)
        {
            this.readRepository = readRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<DepartmentViewModel>> Handle(DepartmentGetAllQuery request, CancellationToken cancellationToken)
        {
           return mapper.Map<IEnumerable<DepartmentViewModel>>(await readRepository.GetAllAsync(cancellationToken, request.Tracking));
            
            
            
        }
    }
}
