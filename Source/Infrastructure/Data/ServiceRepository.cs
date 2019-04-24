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
            await _dbContext.AddAsync(entity);

            await Save();
        }

        public Task Update(Service entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Service entity)
        {
            throw new NotImplementedException();
        }

        private async Task<int> Save()
        {
             return await _dbContext.SaveChangesAsync();
        }
    }
}
