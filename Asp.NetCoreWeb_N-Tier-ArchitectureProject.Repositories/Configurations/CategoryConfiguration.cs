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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category=>category.Id);
            builder.Property(category => category.Id).UseIdentityColumn();
            builder.Property(category => category.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Categories");
        }
    }
}
