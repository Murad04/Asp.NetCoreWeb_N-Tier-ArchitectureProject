using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
