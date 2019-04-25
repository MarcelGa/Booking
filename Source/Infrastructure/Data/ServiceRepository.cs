using Core.Entities;
using Core.Interfaces;

namespace Data
{
    public class ServiceRepository : EfGenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(EfDbContext dbContext) : base(dbContext)
        { 
        }
    }
}
