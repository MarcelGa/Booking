using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly EfDbContext _dbContext;

        public ServiceRepository(EfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Service> GetById(int id)
        {
            return await _dbContext.Services.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ICollection<Service>> Get()
        {
            return await _dbContext.Services.ToArrayAsync();
        }

        public async Task Add(Service entity)
        {
            _dbContext.Add(entity);

            await Save();
        }

        public async Task Update(Service entity)
        {
            _dbContext.Update(entity);

            await Save();
        }

        public async Task Delete(Service entity)
        {
            _dbContext.Remove(entity);

            await Save();
        }

        private async Task<int> Save()
        {
             return await _dbContext.SaveChangesAsync();
        }
    }
}
