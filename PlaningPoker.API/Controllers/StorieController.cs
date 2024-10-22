using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StorieController(IStorieService _storieService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateStorie(StorieDto dto)
        {
            var response = await _storieService.CreateStorie(dto);
            if (!response) return BadRequest("Error in create storie.");
            return Created("", response);
        }
    }
}
