using HotelBooker.Data;
using HotelBooker.Data.Entity;
using HotelBooker.Data.Models.Booking;
using HotelBooker.Services.Interface;
using HotelBooker.Services.Utility;
using Microsoft.EntityFrameworkCore;

namespace HotelBooker.Services.Service
{
    public class BookingService : IBookingService
    {
        private readonly DataContext _context;

        public BookingService(DataContext dataContext)
        {
            _context = dataContext;

        }

        public async Task<BookingModel?> Create(BookingSaveModel saveModel)
        {
            var room = await _context.Rooms
                .Where(x => x.ID == saveModel.RoomId)
                .Include(x => x.Bookings)
                .FirstOrDefaultAsync();


            if (room == null)
            {
                return null;
            }

            if (saveModel.NumberOfGuests > room.Capacity)
            {
                return null;
            }

            if ((saveModel.CheckOut.DayNumber - saveModel.CheckIn.DayNumber) > 0)
            {
                return null;
            }

            var newBooking = new Booking
            {
                CheckIn = saveModel.CheckIn,
                CheckOut = saveModel.CheckOut,
                NumberOfGuests = saveModel.NumberOfGuests,
                RoomId = saveModel.RoomId,
                GuestId = saveModel.GuestId,
                BookingReference = $"HBN-{DateTime.Now.Year}-{BookingUtility.GenerateUniqueReference()}"
            };

            await _context.AddAsync(newBooking);

            var saved = false;

            // Ensure no concurrency conflicts by using optimistic check on specified concurrency property
            while (!saved)
            {
                try
                {
                    if (!room.Bookings.Any(y => y.CheckIn >= saveModel.CheckIn && y.CheckOut <= saveModel.CheckOut))
                    {
                        await _context.SaveChangesAsync();
                        saved = true;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ex.Entries.Single().Reload();
                }
            }


            var result = new BookingModel()
            {
                BookingReference = newBooking.BookingReference,
                CheckIn = newBooking.CheckIn,
                CheckOut = newBooking.CheckOut,
                NumberOfGuests = newBooking.NumberOfGuests,
                Room = new Data.Models.RoomModel()
                {
                    RoomNumber = newBooking.Room.RoomNumber,
                    PricePerNight = newBooking.Room.PricePerNight,
                }
            };

            return result;
        }

        public async Task<BookingModel?> GetBookingByReference(string reference)
        {
            var booking = await _context.Bookings
                .Where(x => EF.Functions.Like(x.BookingReference, reference))
                .Include(x => x.Room)
                .FirstOrDefaultAsync();

            if (booking != null)
            {
                return new BookingModel()
                {
                    BookingReference = booking.BookingReference,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    NumberOfGuests = booking.NumberOfGuests,
                    Room = new Data.Models.RoomModel()
                    {
                        RoomNumber = booking.Room.RoomNumber,
                        PricePerNight = booking.Room.PricePerNight,
                    }
                };
            }

            return null;
        }
    }
}
