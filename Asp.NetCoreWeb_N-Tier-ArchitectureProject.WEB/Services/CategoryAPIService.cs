using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.WEB.Services
{
    public class CategoryAPIService
    {
        private readonly HttpClient _httpClient;

        public CategoryAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<List<CategoryDTO>>>("categories");

            return response.Data;
        }

    }
}
