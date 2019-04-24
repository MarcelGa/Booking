using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Data
{
    public class EfDbInitializer : IDbInitializer
    {
        private readonly EfDbContext _context;
        public EfDbInitializer(EfDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            if (_context.Services.Any())
            {
                return;
            }

            var services = new List<Service>()
            {
                new Service()
                {
                    Id = 1,
                    Description = "popis kadernickej sluzby",
                    Name = "Kadernictvo"
                },
                new Service()
                {
                    Id = 2,
                    Description = "popis pedikury",
                    Name = "Pedikura"
                },
                new Service()
                {
                    Id = 3,
                    Description = "popis manikuri",
                    Name = "Manikura"
                }
            };

            await _context.AddRangeAsync(services);
            await _context.SaveChangesAsync();
        }
    }
}
