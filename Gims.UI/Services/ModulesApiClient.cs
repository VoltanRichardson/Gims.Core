using System.Net.Http.Json;
using Gims.Contracts.Dto;

namespace Gims.UI.Services
{
    public class ModulesApiClient
    {
        private readonly HttpClient _http;

        public ModulesApiClient(HttpClient http)
        {
            _http = http;
        }




        // ------------------------------------------------------------
        // GET ALL MODULES (SysMan-driven)
        // ------------------------------------------------------------
        public async Task<List<ModuleDto>> GetModulesAsync()
        {
            var result = await _http.GetFromJsonAsync<List<ModuleDto>>(
                "api/sysman/modules"
            );

            return result ?? new List<ModuleDto>();
        }

        // ------------------------------------------------------------
        // GET ONE MODULE
        // ------------------------------------------------------------
        public async Task<ModuleDto?> GetModuleAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<ModuleDto>(
                $"api/sysman/modules/{id}"
            );
        }

        // ------------------------------------------------------------
        // CREATE MODULE
        // ------------------------------------------------------------
        public async Task<ModuleDto?> CreateModuleAsync(ModuleDto dto)
        {
            var response = await _http.PostAsJsonAsync(
                "api/sysman/modules", dto
            );

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ModuleDto>();
        }

        // ------------------------------------------------------------
        // UPDATE MODULE
        // ------------------------------------------------------------
        public async Task UpdateModuleAsync(ModuleDto dto)
        {
            var response = await _http.PutAsJsonAsync(
                $"api/sysman/modules/{dto.Id}", dto
            );

            response.EnsureSuccessStatusCode();
        }

        // ------------------------------------------------------------
        // DELETE MODULE
        // ------------------------------------------------------------
        public async Task DeleteModuleAsync(Guid id)
        {
            var response = await _http.DeleteAsync(
                $"api/sysman/modules/{id}"
            );

            response.EnsureSuccessStatusCode();
        }

        // ------------------------------------------------------------
        // GET MODULES AVAILABLE TO A USER (BY ROLE CODES)
        // (Optional — only if you keep this endpoint)
        // ------------------------------------------------------------
        public async Task<List<ModuleDto>> GetAvailableModulesAsync(
            List<string> roleCodes
        )
        {
            var response = await _http.PostAsJsonAsync(
                "api/sysman/modules/available", roleCodes
            );

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<ModuleDto>>();
            return result ?? new List<ModuleDto>();
        }
    }
}