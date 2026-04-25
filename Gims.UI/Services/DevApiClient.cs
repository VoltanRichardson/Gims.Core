using Gims.App.Modules.SysMan.Dto;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Gims.UI.Services;
public class DevApiClient
{
    private readonly HttpClient _http;

    public DevApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<Guid> GetAdminIdAsync()
    {
        return await _http.GetFromJsonAsync<Guid>("api/sysman/dev/admin-id");

    }
    public async Task<UserInfoDto> GetUserInfoAsync()
    {
        // You already have this method
        var adminId = await GetAdminIdAsync();

        // Add a new call to fetch roles
        var roles = await GetUserRolesAsync(adminId);

        return new UserInfoDto
        {
            Id = adminId,
            Roles = roles
        };
    }

    public async Task<List<string>> GetUserRolesAsync(Guid userId)
    {
        return await _http.GetFromJsonAsync<List<string>>(
            $"api/sysman/users/{userId}/roles"
        );
    }
}