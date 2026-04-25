using System.Net.Http.Json;

namespace Gims.UI.Services
{
    public class SubmodulesApiClient
    {
        private readonly HttpClient _http;

        public SubmodulesApiClient(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

        public async Task<List<SubmoduleDto>> GetAvailableSubmodulesAsync(Guid moduleId, List<Guid> roleIds)
        {
            return await _http.PostAsJsonAsync(
                    $"api/sysman/submodules/available/{moduleId}",
                    roleIds
                )
                .Result.Content.ReadFromJsonAsync<List<SubmoduleDto>>();
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            await _http.DeleteAsync($"api/sysman/roles/{id}");
        }
        public record SubmoduleDto(Guid Id, string Name, Guid GimsModuleId);
    }
}