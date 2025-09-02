using HotelBooker.Data;
using HotelBooker.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace HotelBooker.API.Controllers.Testing
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataContext _context;
        public TestController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("ResetData")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> ResetData()
        {

            await _context.RoomTypes.ExecuteDeleteAsync();
            await _context.Guests.ExecuteDeleteAsync();
            await _context.Hotels.ExecuteDeleteAsync();
            await _context.Rooms.ExecuteDeleteAsync();
            await _context.Payments.ExecuteDeleteAsync();
            await _context.Bookings.ExecuteDeleteAsync();

            return Ok();
        }

        [HttpGet("SeedData")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> SeedData()
        {
            _context.AddRange(
                [
                new RoomType() { Name = "Single"},
                new RoomType() { Name = "Double"},
                new RoomType() { Name = "Deluxe"}
                ]
                );

            _context.AddRange(
                [
                new Hotel() { Name = "Hilton", CheckIn = new TimeOnly(14, 00, 00)},
                new Hotel() { Name = "Marriott", CheckIn = new TimeOnly(15, 30, 00)},
                new Hotel() { Name = "Holiday Inn", CheckIn = new TimeOnly(13, 45, 00)}
                ]
                );

            await _context.SaveChangesAsync();

            var hilton = await _context.Hotels
                .Where(x => x.Name == "Hilton")
                .Include(x => x.Rooms)
                .FirstOrDefaultAsync();

            hilton?.Rooms.AddRange(
                [
                new Room() {RoomNumber = 1, Capacity = 1, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Single"), PricePerNight = 30},
                new Room() {RoomNumber = 2, Capacity = 1, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Single"), PricePerNight = 30},
                new Room() {RoomNumber = 3, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 60},
                new Room() {RoomNumber = 4, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 60},
                new Room() {RoomNumber = 5, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 60},
                new Room() {RoomNumber = 6, Capacity = 4, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Deluxe"), PricePerNight = 80}
                ]
                );

            var marriott = await _context.Hotels
                .Where(x => x.Name == "Marriott")
                .Include(x => x.Rooms)
                .FirstOrDefaultAsync();

            marriott?.Rooms.AddRange(
                [
                new Room() {RoomNumber = 1, Capacity = 1, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Single"), PricePerNight = 30},
                new Room() {RoomNumber = 2, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 45},
                new Room() {RoomNumber = 3, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 45},
                new Room() { RoomNumber = 4, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 45},
                new Room() { RoomNumber = 5, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 45},
                new Room() { RoomNumber = 6, Capacity = 5, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Deluxe"), PricePerNight = 60}
                ]
                );
            
            var holidayInn = await _context.Hotels
                .Where(x => x.Name == "Holiday Inn")
                .Include(x => x.Rooms)
                .FirstOrDefaultAsync();

            holidayInn?.Rooms.AddRange(
                [
                new Room() {RoomNumber = 1, Capacity = 1, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Single"), PricePerNight = 30},
                new Room() {RoomNumber = 2, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 50},
                new Room() {RoomNumber = 3, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 50},
                new Room() {RoomNumber = 4, Capacity = 2, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Double"), PricePerNight = 50},
                new Room() {RoomNumber = 5, Capacity = 4, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Deluxe"), PricePerNight = 70},
                new Room() {RoomNumber = 6, Capacity = 5, RoomType = _context.RoomTypes.FirstOrDefault(x => x.Name == "Deluxe"), PricePerNight = 70}
                ]
                );


            _context.Bookings.AddRange(
                [
                new Booking() { BookingReference = "HBN-2025-JS9K3S", CheckIn = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), CheckOut = DateOnly.FromDateTime(DateTime.Now.AddDays(5)), TotalPrice = 90,
                Room = marriott.Rooms.First(),
                Guest = new Guest() { FirstName = "David", LastName = "Mathews", DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)), Email = "123@gmail.com", PhoneNumber = "07392739172", Address = "Unknown"}},
                new Booking() { BookingReference = "HBN-2025-HW8EI4", CheckIn = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), CheckOut = DateOnly.FromDateTime(DateTime.Now.AddDays(6)), TotalPrice = 120,
                Room = hilton.Rooms.First(),
                Guest = new Guest() { FirstName = "Paul", LastName = "Huntington", DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)), Email = "456@gmail.com", PhoneNumber = "62936719362", Address = "Unknown"}},
                new Booking() { BookingReference = "HBN-2025-FI3R39", CheckIn = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), CheckOut = DateOnly.FromDateTime(DateTime.Now.AddDays(3)), TotalPrice = 80,
                Room = hilton.Rooms.Last(),
                Guest = new Guest() { FirstName = "Greg", LastName = "Smith", DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)), Email = "789@gmail.com", PhoneNumber = "72910462778", Address = "Unknown"}},
                new Booking() { BookingReference = "HBN-2025-D92BD7", CheckIn = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), CheckOut = DateOnly.FromDateTime(DateTime.Now.AddDays(4)), TotalPrice = 140,
                Room = holidayInn.Rooms.Last(),
                Guest = new Guest() { FirstName = "Steve", LastName = "MacLeod", DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)), Email = "135@gmail.com", PhoneNumber = "81624333564", Address = "Unknown"}},
                ]
                );


            foreach (var booking in _context.Bookings)
            {
                await _context.Payments.AddAsync(
                    new Payment()
                    {
                        Amount = booking.TotalPrice,
                        PaymentDate = booking.CheckIn,
                        PaymentMethod = "Visa",
                        Booking = booking
                    }
                    );
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
