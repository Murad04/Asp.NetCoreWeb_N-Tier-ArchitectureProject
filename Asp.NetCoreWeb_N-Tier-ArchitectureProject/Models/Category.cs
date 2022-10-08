namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<Product>? Product { get; set; }
    }
}
