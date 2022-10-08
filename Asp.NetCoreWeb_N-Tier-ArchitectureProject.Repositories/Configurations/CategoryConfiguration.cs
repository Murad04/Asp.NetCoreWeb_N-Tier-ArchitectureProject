using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Id).UseIdentityColumn();
            builder.Property(category => category.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Categories");
        }
    }
}
