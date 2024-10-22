using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController(IAuthenticationService _authenticationService) : ControllerBase
    {
        [HttpGet("{registration}")]
        public async Task<IActionResult> GetByIdAsync(Guid registration)
        {
            var entity = await _authenticationService.FindAsync(registration);
            if (entity == null) return NotFound("User not found.");
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddOrUpdateUserDto request)
        {
            var id = await _authenticationService.AddAsync(request);
            return Created(new Uri($"http://{id}"), new object());
        }

        [HttpPut("{registration}")]
        public async Task<IActionResult> UpdateAsync([FromBody] AddOrUpdateUserDto request, Guid registration)
        {
            var entity = await _authenticationService.UpdateAsync(request, registration);
            if (entity == null) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{registration}")]
        public async Task<IActionResult> DeleteAsync(Guid registration)
        {
            var idResult = await _authenticationService.DeleteAsync(registration);
            if (idResult == null) return BadRequest();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto request)
        {
            var token = await _authenticationService.LoginAsync(request);
            return Ok(token);
        }
    }
}
