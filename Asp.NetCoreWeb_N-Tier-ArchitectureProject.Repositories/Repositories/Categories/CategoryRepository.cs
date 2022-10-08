using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Categories;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIDWithProductsAsync(int categoryID)
        {
            return await _context.Categories.Include(c => c.Product).Where(x => x.Id == categoryID).SingleOrDefaultAsync();
        }
    }
}
