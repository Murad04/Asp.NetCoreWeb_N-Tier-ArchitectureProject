namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
