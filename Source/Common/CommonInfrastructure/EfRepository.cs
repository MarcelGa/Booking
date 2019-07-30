using CommonDomain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonInfrastructure
{
   public abstract class EfRepository<T, TId> : IRepository<T, TId>
        where T : AggregateRoot<TId>
        where TId : struct, IEquatable<TId>
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T> GetById(TId id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task Save(T aggregateRoor, CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
