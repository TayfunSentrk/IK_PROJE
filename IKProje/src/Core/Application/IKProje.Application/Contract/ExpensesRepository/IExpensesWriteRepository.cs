using IKProje.Application.Contract.Common;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Contract.ExpensesRepository
{
    public interface IExpensesWriteRepository:IWriteRepository<Expenses>
    {
    }
}
