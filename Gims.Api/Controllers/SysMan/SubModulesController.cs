using Microsoft.AspNetCore.Mvc;
using Gims.Api.Services.SysMan;
using Gims.Contracts.Dto;

namespace Gims.Api.Controllers.SysMan
{
    [ApiController]
    [Route("api/sysman/submodules")]
    public class SubModulesController : ControllerBase
    {
        private readonly ISubmoduleAdminService _service;

        public SubModulesController(ISubmoduleAdminService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubmodules()
        {
            var result = await _service.GetSubmodulesAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSubmodule(Guid id)
        {
            var result = await _service.GetSubmoduleAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubmodule([FromBody] SubmoduleDto dto)
        {
            var created = await _service.CreateSubmoduleAsync(dto);
            return CreatedAtAction(nameof(GetSubmodule), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSubmodule(Guid id, [FromBody] SubmoduleDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            await _service.UpdateSubmoduleAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSubmodule(Guid id)
        {
            await _service.DeleteSubmoduleAsync(id);
            return NoContent();
        }
    }
}