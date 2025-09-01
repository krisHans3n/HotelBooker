using HotelBooker.Data.Models;
using HotelBooker.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {

        private readonly IGuestService _service;
        public GuestController(IGuestService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GuestModel>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _service.GetAll();

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }
    }
}
