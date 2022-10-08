using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Products;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.UnitofWorks;
using AutoMapper;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Services.Products
{
    public class ProductWithNoCachingService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductWithNoCachingService(IGenericRepository<Product> repository, IUnitofWork unitofWork, IProductRepository productRepo, IMapper mapper) : base(repository, unitofWork)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<List<ProductwithCategoryDTO>>> GetProductsWithCategory()
        {
            var data = await _productRepo.GetProductsWithCategory();

            var productsDto = _mapper.Map<List<ProductwithCategoryDTO>>(data);
            return CustomResponseDTO<List<ProductwithCategoryDTO>>.Success(200, productsDto);
        }
    }
}
