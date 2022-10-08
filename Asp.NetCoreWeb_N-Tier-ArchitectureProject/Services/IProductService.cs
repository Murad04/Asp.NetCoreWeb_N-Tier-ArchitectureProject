using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDTO<List<ProductwithCategoryDTO>>> GetProductsWithCategory();
    }
}
