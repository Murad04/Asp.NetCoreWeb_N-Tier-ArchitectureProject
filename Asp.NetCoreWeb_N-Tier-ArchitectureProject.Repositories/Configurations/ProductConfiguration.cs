using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Id).UseIdentityColumn();
            builder.Property(product => product.Name).IsRequired().HasMaxLength(50);
            builder.Property(product => product.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(product => product.Description).IsRequired().HasMaxLength(200);
            builder.Property(product => product.CreatedDate).IsRequired();
            builder.Property(product => product.Stock).IsRequired();
            builder.Property(product => product.CategoryId).IsRequired();

            builder.ToTable("Products");

            // Writing the relation between tables
            builder.HasOne(x => x.Category).WithMany(x => x.Product).HasForeignKey(x => x.CategoryId);
        }
    }
}
