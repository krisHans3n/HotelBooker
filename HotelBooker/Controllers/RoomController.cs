using HotelBooker.Data;
using HotelBooker.Data.Models;
using HotelBooker.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;

        private readonly IRoomService _service;
        public RoomController(ILogger<RoomController> logger, 
            IRoomService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoomModel>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _service.GetAll();

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        [HttpGet("{from}/{to}")]
        [ProducesResponseType(typeof(IEnumerable<RoomModel>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAvailableRooms(DateOnly from, DateOnly to)
        {
            var rooms = await _service.GetAvailableRooms(from, to);

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }
    }
}
