using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext>options) : base(options)
        {
        }
        
        public DbSet<Service> Services { get; set; }

    }
}
