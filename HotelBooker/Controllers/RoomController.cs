using HotelBooker.Data.Models;
using HotelBooker.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _service;
        public RoomController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoomModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var rooms = await _service.GetAll();

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        [HttpGet("available")]
        [ProducesResponseType(typeof(IEnumerable<RoomModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAvailableRooms([FromQuery] DateOnly from, [FromQuery] DateOnly to)
        {
            var rooms = await _service.GetAvailableRooms(from, to);

            return Ok(rooms ?? []);
        }
    }
}
