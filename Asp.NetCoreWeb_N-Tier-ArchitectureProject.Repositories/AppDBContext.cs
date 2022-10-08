﻿using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            var feature = new Product() { ProductFeature = new ProductFeature() };
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
