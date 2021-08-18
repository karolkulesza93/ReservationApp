using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class FloorsController : ControllerBase
    {
        private readonly IFloorService _floorService;

        public FloorsController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FloorDto>>> GetAllFloors()
        {
            var result = await _floorService.GetAllFloors();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FloorDto>> GetFloor([FromRoute] int id)
        {
            var dto = await _floorService.GetFloor(id);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> AddFloor([FromBody] FloorCreateDto dto)
        {
            var id = await _floorService.AddFloor(dto);
            return Created($"/api/floors/{id}", $"New floor added successfully (id={id})");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFloor([FromRoute] int id)
        {
            await _floorService.DeleteFloor(id);
            return Ok($"Floor of id={id} deleted successfully");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFloor([FromBody] FloorUpdateDto dto, [FromRoute] int id)
        {
            await _floorService.UpdateFloor(dto, id);
            return Ok($"Floor of id={id} updated successfully");
        }
    }
}
