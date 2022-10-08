using Asp.NetCoreWeb_N_Tier_ArchitectureProject.API.Filters;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();

            var productsDTO = _mapper.Map<List<ProductDTO>>(products.ToList());

            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTO));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{productID}")]
        public async Task<IActionResult> GetByID(int productID)
        {
            var product = await _service.GetByIDAsync(productID);

            var productDTO = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productDTO));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductswithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDTO));

            var productsDTO = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDTO));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productDTO)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDTO));

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpDelete("{productID}")]
        public async Task<IActionResult> Delete(int productID)
        {
            var product = await _service.GetByIDAsync(productID);

            await _service.DeleteAsync(product);

            var productDTO = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(204));
        }
    }
}
