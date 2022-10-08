using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryID}")]
        public async Task<IActionResult> GetSingleCategoryByIDWithProductsAsync(int categoryID)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIDWithProductsAsync(categoryID));
        }
    }
}
