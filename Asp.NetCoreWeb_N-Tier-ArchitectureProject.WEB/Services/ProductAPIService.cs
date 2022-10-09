using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.WEB.Services
{
    public class ProductAPIService
    {
        private readonly HttpClient _httpClient;

        public ProductAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductwithCategoryDTO>> GetProductwithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<List<ProductwithCategoryDTO>>>("products/GetProductswithCategory");

            return response.Data;
        }

        public async Task<ProductDTO> SaveAsync(ProductDTO productDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("products", productDTO);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDTO<ProductDTO>>();

            return responseBody.Data;
        }

        public async Task<ProductDTO> GetByIDAsync(int productID)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<ProductDTO>>($"products/{productID}");
            return response.Data;
        }

        public async Task<bool> RemoveAsync(int productID)
        {
            var response = await _httpClient.DeleteAsync($"products/{productID}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(ProductDTO productDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("products", productDTO);

            return response.IsSuccessStatusCode;
        }
    }
}
