using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services
{
    public interface IProductService:IService<Product>
    {
        Task<CustomResponseDTO<List<ProductwithCategoryDTO>>> GetProductsWithCategory();
    }
}
