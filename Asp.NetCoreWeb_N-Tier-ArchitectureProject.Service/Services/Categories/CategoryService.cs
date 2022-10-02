using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Categories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Repositories.Categories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.UnitofWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Services.Categories
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitofWork unitofWork, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitofWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDTO<CategorywithProductsDTO>> GetSingleCategoryByIDWithProductsAsync(int categoryID)
        {
            var category = await _categoryRepository.GetSingleCategoryByIDWithProductsAsync(categoryID);

            var categoryDTO = _mapper.Map<CategorywithProductsDTO>(category);

            return CustomResponseDTO<CategorywithProductsDTO>.Success(200,categoryDTO);
        }
    }
}
