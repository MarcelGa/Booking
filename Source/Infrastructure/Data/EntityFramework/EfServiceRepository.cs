using Core.Entities;
using Core.Interfaces.Repositories;

namespace Data
{
    public class EfServiceRepository : EfGenericRepository<Service>, IServiceRepository
    {
        public EfServiceRepository(EfDbContext dbContext) : base(dbContext)
        { 
        }
    }
}
