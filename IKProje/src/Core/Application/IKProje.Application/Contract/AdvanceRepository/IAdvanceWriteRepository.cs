using IKProje.Application.Contract.Common;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Contract.AdvanceRepository
{
    public interface IAdvanceWriteRepository:IWriteRepository<Advance>
    {
        Task<Tuple<Personel, Advance>> ControlofAdvance(Personel personel,Advance advance);
    }
}
