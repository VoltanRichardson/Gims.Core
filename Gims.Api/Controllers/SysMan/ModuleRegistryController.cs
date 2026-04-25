using Microsoft.AspNetCore.Mvc;
using Gims.App.Modules.SysMan.Dto;

    [ApiController]
    [Route("api/sysman/registry")]
    public class ModuleRegistryController : ControllerBase
    {
        [HttpGet("modules")]
        public IActionResult GetModuleRegistry()
        {
            return Ok(new[]
            {
                new { Key = "sysman", Name = "System Management" },
                new { Key = "claims", Name = "Claims" }
            });
        }
    }
