using System.Net.Http.Json;
using Gims.App.Modules.SysMan.Dto;
using Gims.Contracts.Dto;

namespace Gims.UI.Services
{
    public class PermissionsApiClient
    {
        private readonly HttpClient _http;

        public PermissionsApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PermissionDto>> GetPermissionsAsync(Guid submoduleId)
        {
            var result = await _http.GetFromJsonAsync<List<PermissionDto>>(
                $"api/sysman/submodules/{submoduleId}/permissions");

            return result ?? new List<PermissionDto>();
        }

        public async Task<PermissionDto?> GetPermissionAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<PermissionDto?>(
                $"api/sysman/permissions/{id}");
        }

        public async Task CreatePermissionAsync(PermissionDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/sysman/permissions", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdatePermissionAsync(PermissionDto dto)
        {
            var response = await _http.PutAsJsonAsync(
                $"api/sysman/permissions/{dto.Id}", dto);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePermissionAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/sysman/permissions/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}