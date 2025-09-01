using HotelBooker.Data.Models;
using HotelBooker.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IHotelService _service;

        public HotelController(ILogger<HotelController> logger,
            IHotelService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet("{name}")]
        [ProducesResponseType(typeof(HotelModel), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _service.GetHotelByName(name);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }
    }
}
