using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAllRooms()
        {
            var result = await _roomService.GetAllRooms();
            return Ok(result);
        }

        [HttpGet("floor/{number}")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAllRoomsOnFloor([FromRoute] int number)
        {
            var result = await _roomService.GetAllRoomsOnFloor(number);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom([FromRoute] int id)
        {
            var dto = await _roomService.GetRoom(id);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> AddRoom([FromBody] RoomCreateDto dto)
        {
            var id = await _roomService.AddRoom(dto);
            return Created($"/api/rooms/{id}", $"New room added successfully (id={id})");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoom([FromRoute] int id)
        {
            await _roomService.DeleteRoom(id);
            return Ok($"Room of id={id} deleted successfully");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoom([FromBody] RoomUpdateDto dto, [FromRoute] int id)
        {
            await _roomService.UpdateRoom(dto, id);
            return Ok($"Room of id={id} updated successfully");
        }
    }
}
