using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var customResponse = await _productService.GetProductsWithCategory();
            return View(customResponse.Data);
        }

        public async Task<IActionResult> Save()
        {
            var categories = await _categoryService.GetAllAsync();

            var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDTO, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(_mapper.Map<Product>(productDTO));
                return RedirectToAction("Index");
            }

            var categories = await _categoryService.GetAllAsync();

            var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDTO, "Id", "Name");

            return View();
        }

        public async Task<IActionResult> Update(int productID)
        {
            var product = await _productService.GetByIDAsync(productID);

            var categories = await _categoryService.GetAllAsync();

            var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDTO, "Id", "Name", product.CategoryId);

            return View(_mapper.Map<ProductDTO>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(_mapper.Map<Product>(productDTO));
                return RedirectToAction("Index");
            }
            var categories = await _categoryService.GetAllAsync();

            var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories.ToList());

            ViewBag.categories = new SelectList(categoriesDTO, "Id", "Name", productDTO.CategoryId);

            return View(productDTO);
        }

        public async Task<IActionResult> Delete(int productID)
        {
            var product = await _productService.GetByIDAsync(productID);
            
            await _productService.DeleteAsync(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
