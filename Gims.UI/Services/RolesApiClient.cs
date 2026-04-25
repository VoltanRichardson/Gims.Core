using System.Net.Http.Json;
using Gims.App.Modules.SysMan.Dto;
using Gims.Contracts.Dto;

namespace Gims.UI.Services
{
    public class RolesApiClient
    {
        private readonly HttpClient _http;

        public RolesApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<RoleDto>> GetRolesAsync()
            => await _http.GetFromJsonAsync<List<RoleDto>>("api/roles")
               ?? new List<RoleDto>();

        public async Task<RoleDto?> GetRoleAsync(Guid id)
            => await _http.GetFromJsonAsync<RoleDto>($"api/roles/{id}");

        public async Task CreateRoleAsync(CreateRoleRequest request)
            => await _http.PostAsJsonAsync("api/roles", request);

        public async Task UpdateRoleAsync(UpdateRoleRequest request)
            => await _http.PutAsJsonAsync($"api/roles/{request.Id}", request);

        public async Task DeleteRoleAsync(Guid id)
            => await _http.DeleteAsync($"api/roles/{id}");
    }
}