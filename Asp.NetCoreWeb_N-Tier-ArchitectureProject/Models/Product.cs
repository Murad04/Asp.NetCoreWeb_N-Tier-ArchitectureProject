namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ProductFeature ProductFeature { get; set; } = null!;
    }
}
