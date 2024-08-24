using IKProje.Application.Contract.PermissionRepository;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.Common;
using IKProje.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.PermissionRepositories
{
    public class PermissionReadRepository:ReadRepository<Permission>,IPermissionReadRepository
    {
        public PermissionReadRepository(IKProjeDbContext context):base(context) { }

        public async Task<IEnumerable<Permission>> GetAllIncludePermission(
        Expression<Func<Permission, bool>>? expression = null,
        Func<IQueryable<Permission>, IIncludableQueryable<Permission, object>>? include = null,
        CancellationToken token = default)
        {
                IQueryable<Permission> query = dbSet.AsQueryable();

                if (expression != null)
                {
                    query = query.Where(expression);
                }

                if (include != null)
                {
                    query = include(query);
                }

                return await query.ToListAsync(token);
            }
    }
}
