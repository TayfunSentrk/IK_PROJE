using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.Common;
using IKProje.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.ExpensesRepositories
{
    public class ExpensesReadRepository:ReadRepository<Expenses>,IExpensesReadRepository
    {
        public ExpensesReadRepository(IKProjeDbContext context) : base(context) { }
         
        
    }
}
