using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokerController(IPokerService _pokerService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreatePoker(PokerDto dto)
        {
            var response = await _pokerService.CreatePoker(dto);
            if (!response) return BadRequest("Error in create room.");
            return Created("", response);
        }
    }
}
