using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var customResponse = await _productService.GetProductsWithCategory();
            return View(customResponse.Data);
        }
    }
}
