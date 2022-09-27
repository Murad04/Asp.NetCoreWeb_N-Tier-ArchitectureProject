using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            var feature = new Product() { ProductFeature = new ProductFeature() };
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
    }
}
