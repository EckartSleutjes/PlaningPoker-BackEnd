using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorieController(IStorieService _storieService) : ControllerBase
    {

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetStorieById(Guid id)
        //{
        //    var response = await _storieService.GetRoomById(id);
        //    if (response is null) return BadRequest("Error in get storie.");
        //    return Ok(response);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateRoom(RoomDto dto)
        //{
        //    var response = await _roomService.CreateRoom(dto);
        //    if (!response) return BadRequest("Error in create room.");
        //    return Created("", response);
        //}
    }
}
