using CommonDomain.Model;
using CommonDomain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        private readonly IDomainEventDispatcher _dispatcher;

        protected EfRepository(DbContext dbContext, IDomainEventDispatcher domainEventDispatcher)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            _dispatcher = domainEventDispatcher;
        }

        private IQueryable<T> Get(bool trackChanges = true)
        {
            return trackChanges ? _dbSet.AsQueryable() : _dbSet.AsNoTracking().AsQueryable();
        }

        protected Task<List<T>> Search(Expression<Func<T, bool>> predicate, bool trackChanges, CancellationToken cancellationToken = default)
        {
            return Get(trackChanges).Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<T> GetById(TId id, bool trackChanges = true, CancellationToken cancellationToken = default)
        {
            return await Get(trackChanges).FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            //dispatch domain events
            var domainEventEntities = _dbContext.ChangeTracker.Entries<T>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents?.Any() ?? false);

            foreach (var aggregateRoot in domainEventEntities)
            {
                var events = aggregateRoot.DomainEvents;
                aggregateRoot.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await _dispatcher.Dispatch(domainEvent, cancellationToken);
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task Create(T aggregate, CancellationToken cancellationToken = default)
        {
            return _dbSet.AddAsync(aggregate, cancellationToken);
        }
        
        public Task Update(T aggregate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dbSet.Update(aggregate));
        }

        public Task Delete(T aggregate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dbSet.Remove(aggregate));
        }
    }
}
