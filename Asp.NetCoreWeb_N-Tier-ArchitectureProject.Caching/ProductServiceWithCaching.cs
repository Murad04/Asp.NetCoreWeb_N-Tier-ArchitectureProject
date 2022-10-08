using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Products;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Exceptions;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.UnitofWorks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Caching
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey = "Productscache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _productRepository;
        private readonly IUnitofWork _unitOfWork;

        public ProductServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IProductRepository productRepository, IUnitofWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;


            if (!_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _productRepository.GetProductsWithCategory().Result);
            }
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _productRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _productRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Product entity)
        {
            _productRepository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(CacheProductKey));
        }

        public Task<Product> GetByIDAsync(int id)
        {
            var product = _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id);

            if (product == null) throw new NotFoundException($"{typeof(Product).Name}({id}) not found");

            return Task.FromResult(product);
        }

        public Task<CustomResponseDTO<List<ProductwithCategoryDTO>>> GetProductsWithCategory()
        {
            var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);

            var productsWithCategoryDTO = _mapper.Map<List<ProductwithCategoryDTO>>(products);

            return Task.FromResult(CustomResponseDTO<List<ProductwithCategoryDTO>>.Success(200, productsWithCategoryDTO));
        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            _productRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
        }

        public async Task UpdateAsync(Product entity)
        {
            _productRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllProducts()
        {
            _memoryCache.Set(CacheProductKey, _productRepository.GetAll().ToListAsync());
        }
    }
}
