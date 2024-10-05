using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController(IRoomService _roomService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(Guid id)
        {
            var response = await _roomService.GetRoomById(id);
            if (response is null) return BadRequest("Error in get room.");
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomDto dto)
        {
            var response = await _roomService.CreateRoom(dto);
            if (!response) return BadRequest("Error in create room.");
            return Created("", response);
        }
    }
}
