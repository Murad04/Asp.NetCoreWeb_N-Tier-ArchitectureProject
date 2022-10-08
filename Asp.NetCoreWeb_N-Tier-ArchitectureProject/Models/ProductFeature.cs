namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public decimal Weight { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
