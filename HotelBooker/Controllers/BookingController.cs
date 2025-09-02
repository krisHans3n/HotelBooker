using HotelBooker.Data.Models.Booking;
using HotelBooker.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet("{reference}")]
        [ProducesResponseType(typeof(BookingModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetBookingByReference(string reference)
        {
            var bookingDetails = await _service.GetBookingByReference(reference);

            if (bookingDetails == null)
            {
                return NotFound();
            }

            return Ok(bookingDetails);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookingModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] BookingSaveModel saveModel)
        {
            var result = await _service.Create(saveModel);

            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(
                nameof(GetBookingByReference),
                new { reference = result.BookingReference},
                result
                );
        }

    }
}
