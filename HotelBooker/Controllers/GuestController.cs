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
        [ProducesResponseType(typeof(IEnumerable<GuestModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var guests = await _service.GetAll();

            return Ok(guests ?? []);
        }
    }
}
