using HotelBooker.Data.Models;
using HotelBooker.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelController(IHotelService service)
        {
            _service = service;
        }


        [HttpGet("{name}")]
        [ProducesResponseType(typeof(HotelModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetHotelByName(string name)
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
