using IKProje.Application.Contract.Common;
using IKProje.Domain.Entities.Base;
using IKProje.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.Common
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {

        protected readonly IKProjeDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public WriteRepository(IKProjeDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            dbSet = dbContext.Set<T>() ?? throw new ArgumentNullException("DbContext is null");
        }

        public async Task<bool> AddAsync(T entity, CancellationToken token)
        {
            await dbSet.AddAsync(entity);
       
            return true;
          
        }

        public bool RemoveById(string id, CancellationToken token)
        {
            T? entity = dbSet.Find(id);
            if (entity == null)
                return false;

            PropertyInfo? isActive = typeof(T).GetProperty("IsActive");
            if (isActive != null && isActive.PropertyType == typeof(bool))
            {
                isActive.SetValue(entity, false);

                // Varlığın durumunu güncellemek için EntityState.Modified olarak işaretleyebilirsiniz
                dbContext.Entry(entity).State = EntityState.Modified;
             
                return true;
            }
            else
            return false;
        }

        public async Task<int> SaveAsync(CancellationToken token)
        => await dbContext.SaveChangesAsync();

        public bool Update(T entity, CancellationToken token)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
    }
}
