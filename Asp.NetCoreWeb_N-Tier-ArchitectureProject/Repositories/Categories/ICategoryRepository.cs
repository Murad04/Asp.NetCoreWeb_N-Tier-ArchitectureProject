using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Categories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIDWithProductsAsync(int categoryID);
    }
}
