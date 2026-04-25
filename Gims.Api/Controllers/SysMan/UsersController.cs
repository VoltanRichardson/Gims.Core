using Microsoft.AspNetCore.Mvc;
using Gims.Api.Services.SysMan;
using Gims.Contracts.Dto;

namespace Gims.Api.Controllers.SysMan
{
    [ApiController]
    [Route("api/sysman/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserAdminService _service;

        public UsersController(IUserAdminService service)
        {
            _service = service;
        }

        // GET: api/sysman/users
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            var users = await _service.GetUsersAsync();
            return Ok(users);
        }

        // GET: api/sysman/users/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            var user = await _service.GetUserAsync(id);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        // GET: api/sysman/users/{id}/roles
        [HttpGet("{id:guid}/roles")]
        public async Task<ActionResult<List<string>>> GetUserRoles(Guid id)
        {
            var roles = await _service.GetUserRolesAsync(id);
            if (roles is null)
                return NotFound();

            return Ok(roles);
        }

        // POST: api/sysman/users
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto dto)
        {
            var created = await _service.CreateUserAsync(dto);
            return CreatedAtAction(nameof(GetUser), new { id = created.Id }, created);
        }

        // PUT: api/sysman/users/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            await _service.UpdateUserAsync(dto);
            return NoContent();
        }

        // DELETE: api/sysman/users/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _service.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
