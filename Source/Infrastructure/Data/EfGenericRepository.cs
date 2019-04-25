using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected EfGenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).AsNoTracking().ToListAsync();
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);

            await Save();
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);

            _dbSet.Update(entity);

            await Save();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Attach(entity);

            _dbSet.Remove(entity);

            await Save();
        }

        protected async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
