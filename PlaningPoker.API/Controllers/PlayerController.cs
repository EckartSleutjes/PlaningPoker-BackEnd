using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController(IPlayerService _playerService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(Guid id)
        {
            var response = await _playerService.GetPlayerById(id);
            if (response is null) return BadRequest("Error in get player.");
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(PlayerDto dto)
        {
            var response = await _playerService.CreatePlayer(dto);
            if (!response) return BadRequest("Error in create player.");
            return Created("", response);
        }

        [HttpGet("room/{roomId}")]
        public IActionResult GetPlayersByRoomId(Guid roomId)
        {
            var response = _playerService.GetPlayersByRoomId(roomId).ToList();
            if (response is null || response.Count == 0) return NotFound("None players in room.");
            return Ok(response);
        }
    }
}
