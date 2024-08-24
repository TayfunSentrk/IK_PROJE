using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.Common;
using IKProje.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.AdvanceRepositories
{
    public class AdvanceReadRepository:ReadRepository<Advance>,IAdvanceReadRepository
    {
        public AdvanceReadRepository(IKProjeDbContext context) : base(context) { }
        
    }
}
