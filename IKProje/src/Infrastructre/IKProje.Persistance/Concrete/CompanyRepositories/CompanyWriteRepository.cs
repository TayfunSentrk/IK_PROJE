using IKProje.Application.Contract.CompanyRepositories;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.Common;
using IKProje.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.CompanyRepositories
{
    public class CompanyWriteRepository:WriteRepository<Company>,ICompanyWriteRepository
    {
        public CompanyWriteRepository(IKProjeDbContext dbContext) : base(dbContext) { }
    }
}
