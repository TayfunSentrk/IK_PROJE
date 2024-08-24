using IKProje.Application.Contract.Common;
using IKProje.Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Contract.PermissionRepository
{
    public interface IPermissionReadRepository:IReadRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetAllIncludePermission(
        Expression<Func<Permission, bool>>? expression = null,
        Func<IQueryable<Permission>, IIncludableQueryable<Permission, object>>? include = null,
        CancellationToken token = default);
        // Other repository methods...
    }
}

