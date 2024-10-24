using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using System.Security.Claims;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorieController(IStorieService _storieService) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateStorie(StorieDto dto)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var response = await _storieService.CreateStorie(dto, userId);
            if (!response) return BadRequest("Error in create storie.");
            return Created("", response);
        }
    }
}
