using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using System.Security.Claims;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController(IRoomService _roomService, IStorieService _storieService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(Guid id)
        {
            var response = await _roomService.GetRoomById(id);
            if (response is null) return BadRequest("Error in get room.");
            return Ok(response);
        }

        [HttpGet("tag/{tagRoom}")]
        public async Task<IActionResult> GetRoomByTag(string tagRoom)
        {
            var response = await _roomService.GetRoomByTag(tagRoom);
            if (response is null) return BadRequest("Error in get room by tag.");
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRoom(RoomDto dto)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var response = await _roomService.CreateRoom(dto, userId);
            if (response.Equals(Guid.Empty)) return BadRequest("Error in create room.");
            return Created("", response);
        }
        [HttpGet("{id}/stories")]
        public async Task<IActionResult> GetStoriesByRoomId(Guid id, [FromQuery] bool? played = null)
        {
            var response = await _storieService.GetStoriesByRoomId(id, played);
            return Ok(response);
        }
    }
}
