using Gims.Infrastructure.EF.Configurations.SysMan;
using Gims.Infrastructure.EF.Configurations.SysMan.Seed;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/sysman/dev")]
public class DevController : ControllerBase
{
    private readonly SeedState _state;

    public DevController(SeedState state)
    {
        _state = state;
    }

    [HttpGet("admin-id")]
    public Guid GetAdminId() => _state.AdminId;
}