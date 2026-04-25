using System.Net.Http.Json;
using Gims.App.Modules.SysMan.Dto;
using Gims.Contracts.Dto;

namespace Gims.UI.Services
{
    public class UsersApiClient
    {
        private readonly HttpClient _http;

        public UsersApiClient(HttpClient http)
        {
            _http = http;
        }

        // GET: api/sysman/users
        public async Task<List<UserDto>> GetUsersAsync()
        {
            var result = await _http.GetFromJsonAsync<List<UserDto>>("/api/sysman/users");
            return result ?? new List<UserDto>();
        }

        // GET: api/sysman/users/{id}
        public async Task<UserDto?> GetUserAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<UserDto?>($"/api/sysman/users/{id}");
        }

        // GET: api/sysman/users/{id}/roles
        public async Task<UserDto?> GetUserRolesAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<UserDto?>($"/api/sysman/users/{id}/roles");
        }


        // POST: api/sysman/users
        public async Task CreateUserAsync(UserDto user)
        {
            var response = await _http.PostAsJsonAsync("/api/sysman/users", user);
            response.EnsureSuccessStatusCode();
        }

        // PUT: api/sysman/users/{id}
        public async Task UpdateUserAsync(UserDto user)
        {
            var response = await _http.PutAsJsonAsync($"/api/sysman/users/{user.Id}", user);
            response.EnsureSuccessStatusCode();
        }

        // DELETE: api/sysman/users/{id}
        public async Task DeleteUserAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"/api/sysman/users/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}