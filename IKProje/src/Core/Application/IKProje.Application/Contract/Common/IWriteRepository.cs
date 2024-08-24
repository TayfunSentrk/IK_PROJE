using IKProje.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Contract.Common
{
    public interface IWriteRepository<T> where T : BaseEntity, new()
    {
        bool Update(T entity, CancellationToken token);

        bool RemoveById(string id, CancellationToken token);

        Task<bool> AddAsync(T entity, CancellationToken token);
        Task<int> SaveAsync( CancellationToken token);
    }
}
