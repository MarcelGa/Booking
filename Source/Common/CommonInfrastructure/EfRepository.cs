using CommonDomain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonInfrastructure
{
   public abstract class EfRepository<T, TId> : IRepository<T, TId>
        where T : AggregateRoot<TId>
        where TId : struct, IEquatable<TId>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        protected EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        private IQueryable<T> Get(bool trackChanges = true)
        {
            return trackChanges ? _dbSet.AsQueryable() : _dbSet.AsNoTracking().AsQueryable();
        }

        protected async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate, bool trackChanges, CancellationToken cancellationToken = default)
        {
            return await Get(trackChanges).Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<T> GetById(TId id, bool trackChanges = true, CancellationToken cancellationToken = default)
        {
            return await Get(trackChanges).FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
