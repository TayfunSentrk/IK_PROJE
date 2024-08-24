using IKProje.Application.Contract.Common;
using IKProje.Domain.Entities.Base;
using IKProje.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.Common
{
    public class ReadRepository<T>:IReadRepository<T> where T : BaseEntity,new()
    {
        protected readonly IKProjeDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public ReadRepository(IKProjeDbContext dbContext)
        {
            this.dbContext = dbContext?? throw new ArgumentNullException(nameof(dbContext));
            dbSet = dbContext.Set<T>() ?? throw new ArgumentNullException("DbContext is null");
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression, CancellationToken token=default,bool tracking=true)
        { 
            var query=dbSet.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            
            if (expression == null)
            {
                return await query.ToListAsync();
            }
            return await query.Where(expression).ToListAsync();

        }
        public async Task<IEnumerable<T>> GetAllAsync( CancellationToken token = default, bool tracking = true)
        {
            var query = dbSet.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();


            return await query.ToListAsync();

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken token=default, bool tracking = true)
        {
            var query = dbSet.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetQueryable()
        {
            return dbSet.AsQueryable();
        }


        public async Task<IEnumerable<T>> GetAllInclude(
        Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        CancellationToken token = default)
        {
            IQueryable<T> query = dbSet;

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

        public async Task<T> GetSingleInclude(
            Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            CancellationToken token = default)
        {
            IQueryable<T> query = dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(token);
        }
    }
}

