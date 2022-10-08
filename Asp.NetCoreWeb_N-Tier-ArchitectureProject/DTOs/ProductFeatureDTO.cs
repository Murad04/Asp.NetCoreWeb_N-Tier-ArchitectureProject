namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs
{
    public class ProductFeatureDTO
    {
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public decimal Weight { get; set; }
        public int ProductId { get; set; }
    }
}
