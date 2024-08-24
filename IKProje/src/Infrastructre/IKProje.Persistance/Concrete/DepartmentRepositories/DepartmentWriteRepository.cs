using IKProje.Application.Contract.DepartmentRepositories;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.Common;
using IKProje.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.DepartmentRepositories
{
    public class DepartmentWriteRepository:WriteRepository<Department>,IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(IKProjeDbContext dbContext) : base(dbContext) { }
    }
}
