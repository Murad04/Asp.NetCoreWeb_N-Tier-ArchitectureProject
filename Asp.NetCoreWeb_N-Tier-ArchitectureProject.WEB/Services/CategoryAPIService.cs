namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.WEB.Services
{
    public class CategoryAPIService
    {
        private readonly HttpClient _httpClient;

        public CategoryAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
