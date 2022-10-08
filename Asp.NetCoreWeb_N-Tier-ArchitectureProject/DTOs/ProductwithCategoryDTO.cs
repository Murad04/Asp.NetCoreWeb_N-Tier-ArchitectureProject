using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs
{
    public class ProductwithCategoryDTO : ProductDTO
    {
        public Category Category { get; set; } = null!;
    }
}
