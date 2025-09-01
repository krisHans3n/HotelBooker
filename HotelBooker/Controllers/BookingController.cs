using HotelBooker.Data.Models.Booking;
using HotelBooker.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _service;
        public BookingController(ILogger<BookingController> logger, 
            IBookingService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{reference}")]
        [ProducesResponseType(typeof(BookingModel), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookingByReference(string reference)
        {
            var bookingDetails = await _service.GetBookingByReference(reference);

            if (bookingDetails == null)
            {
                return NotFound();
            }

            return Ok(bookingDetails);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookingModel), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] BookingSaveModel saveModel)
        {
            var result = await _service.Create(saveModel);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}
