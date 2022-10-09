using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.WEB.Filters;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.WEB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.WEB.Controllers
{
    /// <summary>
    /// !!! Commented codes are used for connecting WEB Layer with other layers
    /// </summary>


    public class ProductController : Controller
    {
        /*private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }*/

        private readonly ProductAPIService _productAPIService;
        private readonly CategoryAPIService _categoryAPIService;

        public ProductController(ProductAPIService productAPIService, CategoryAPIService categoryAPIService)
        {
            _productAPIService = productAPIService;
            _categoryAPIService = categoryAPIService;
        }

        public async Task<IActionResult> Index()
        {
            var customResponse = await _productAPIService.GetProductwithCategoryAsync();
            //var customResponse = await _productService.GetProductsWithCategory();
            return View(customResponse);
        }

        public async Task<IActionResult> Save()
        {
            var categories = await _categoryAPIService.GetAllAsync();
            //var categories = await _categoryService.GetAllAsync();

            //var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories.ToList());

            ViewBag.categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productAPIService.SaveAsync(productDTO);

                //await _productService.AddAsync(_mapper.Map<Product>(productDTO));
                return RedirectToAction("Index");
            }

            var categories = await _categoryAPIService.GetAllAsync();

            //var categories = await _categoryService.GetAllAsync();

            //var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories.ToList());

            //ViewBag.categories = new SelectList(categoriesDTO, "Id", "Name");
            ViewBag.categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        public async Task<IActionResult> Update(int productID)
        {
            var product = await _productAPIService.GetByIDAsync(productID);
            //var product = await _productService.GetByIDAsync(productID);

            var categories = await _categoryAPIService.GetAllAsync();
            //var categories = await _categoryService.GetAllAsync();

            //var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories.ToList());

            //ViewBag.categories = new SelectList(categoriesDTO, "Id", "Name", product.CategoryId);
            ViewBag.categories = new SelectList(categories, "Id", "Name", product.CategoryId);

            //return View(_mapper.Map<ProductDTO>(product));
            return View(product);
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpPost]
        public async Task<IActionResult> Update(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productAPIService.UpdateAsync(productDTO);
                //await _productService.UpdateAsync(_mapper.Map<Product>(productDTO));
                return RedirectToAction("Index");
            }
            var categories = await _categoryAPIService.GetAllAsync();
            //var categories = await _categoryService.GetAllAsync();

            //var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories.ToList());

            ViewBag.categories = new SelectList(categories, "Id", "Name", productDTO.CategoryId);
            //ViewBag.categories = new SelectList(categoriesDTO, "Id", "Name", productDTO.CategoryId);

            return View(productDTO);
        }

        public async Task<IActionResult> Delete(int productID)
        {
            var product = await _productAPIService.GetByIDAsync(productID);
            //var product = await _productService.GetByIDAsync(productID);

            await _productAPIService.RemoveAsync(product.Id);
            //await _productService.DeleteAsync(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
