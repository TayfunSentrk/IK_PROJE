using IKProje.Application.Contract.VocationRepositories;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.Common;
using IKProje.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.VocationRepositories
{
    public class VocationWriteRepository:WriteRepository<Vocation>,IVocationWriteRepository
    {
        public VocationWriteRepository(IKProjeDbContext dbContext) : base(dbContext) { }
    }
}
