using Microsoft.AspNetCore.Mvc;
using Gims.Contracts.Dto;
using Gims.Api.Services.SysMan;

namespace Gims.Api.Controllers.SysMan
{
    [ApiController]
    [Route("api/sysman/modules")]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleAdminService _service;
        private readonly IConfiguration _config;

        public ModulesController(IModuleAdminService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [HttpGet("debug-conn")]
        public IActionResult DebugConnection()
        {
            return Ok(new
            {
                ConfigValue = _config.GetConnectionString("DefaultConnection")
            });
        }

        [HttpGet]
        public async Task<ActionResult<List<ModuleDto>>> GetModules()
        {
            return Ok(await _service.GetModulesAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ModuleDto>> GetModule(Guid id)
        {
            var module = await _service.GetModuleAsync(id);
            return module is null ? NotFound() : Ok(module);
        }

        [HttpPost]
        public async Task<ActionResult<ModuleDto>> CreateModule([FromBody] ModuleDto dto)
        {
            var created = await _service.CreateModuleAsync(dto);
            return CreatedAtAction(nameof(GetModule), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateModule(Guid id, [FromBody] ModuleDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            await _service.UpdateModuleAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteModule(Guid id)
        {
            await _service.DeleteModuleAsync(id);
            return NoContent();
        }

        [HttpPost("available")]
        public async Task<ActionResult<List<ModuleDto>>> GetAvailableModules([FromBody] List<string> roleCodes)
        {
            var modules = await _service.GetAvailableModulesAsync(roleCodes);
            return Ok(modules);
        }
    }
}