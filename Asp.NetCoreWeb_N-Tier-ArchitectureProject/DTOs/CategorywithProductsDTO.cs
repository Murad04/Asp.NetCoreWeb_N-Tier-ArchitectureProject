using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs
{
    public class CategorywithProductsDTO : CategoryDTO
    {
        public List<Product>? Products { get; set; }
    }
}
