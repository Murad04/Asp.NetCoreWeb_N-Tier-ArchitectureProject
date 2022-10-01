using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _productService;

        public ProductsController(IMapper mapper, IService<Product> productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            var productsDTO = _mapper.Map<List<ProductDTO>>(products.ToList());

            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTO));
        }

        [HttpGet("{productID}")]
        public async Task<IActionResult> GetByID(int productID)
        {
            var product = await _productService.GetByIDAsync(productID);

            var productDTO = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productDTO));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDTO));

            var productsDTO = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDTO));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productDTO)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDTO));

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(204));
        }

        [HttpDelete("{productID}")]
        public async Task<IActionResult> Delete(int productID)
        {
            var product = await _productService.GetByIDAsync(productID);

            await _productService.DeleteAsync(product);

            var productDTO = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(204));
        }
    }
}
