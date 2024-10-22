using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StoriePlayerController(IStoriePlayerService _storiePlayerService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateStoriePlayer(StoriePlayerDto dto)
        {
            var response = await _storiePlayerService.CreateStoriePlayer(dto);
            if (!response) return BadRequest("Error in create storie player.");
            return Created("", response);
        }
    }
}
