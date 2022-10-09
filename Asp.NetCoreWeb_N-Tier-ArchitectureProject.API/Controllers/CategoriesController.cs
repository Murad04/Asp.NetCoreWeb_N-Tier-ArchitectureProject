using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{categoryID}")]
        public async Task<IActionResult> GetSingleCategoryByIDWithProductsAsync(int categoryID)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIDWithProductsAsync(categoryID));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories.ToList());

            return CreateActionResult(CustomResponseDTO<List<CategoryDTO>>.Success(200, categoriesDTO));
        }
    }
}
