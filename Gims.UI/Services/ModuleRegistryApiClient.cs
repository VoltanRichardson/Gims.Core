using System.Net.Http.Json;

namespace Gims.UI.Services
{
    public class ModuleRegistryApiClient
    {
        private readonly HttpClient _http;

        public ModuleRegistryApiClient(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

        public async Task<List<ModuleRegistryDto>> GetModuleRegistryAsync()
        {
            return await _http.GetFromJsonAsync<List<ModuleRegistryDto>>("api/sysman/registry/modules");
        }
    }

    public record ModuleRegistryDto(string Key, string Name);
}