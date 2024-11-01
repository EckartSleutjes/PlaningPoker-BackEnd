using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController(IAuthenticationService _authenticationService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var entity = await _authenticationService.FindAsync(id);
            if (entity == null) return NotFound("User not found.");
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddOrUpdateUserDto request)
        {
            var id = await _authenticationService.AddAsync(request);
            return Created(new Uri($"https://{id}"), new object());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] AddOrUpdateUserDto request, Guid id)
        {
            var entity = await _authenticationService.UpdateAsync(request, id);
            if (entity == null) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var idResult = await _authenticationService.DeleteAsync(id);
            if (idResult == null) return BadRequest();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto request)
        {
            var token = await _authenticationService.LoginAsync(request);
            return Ok(new { token });
        }
    }
}
