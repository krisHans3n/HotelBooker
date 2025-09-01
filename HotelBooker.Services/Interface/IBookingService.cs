using HotelBooker.Data.Models.Booking;

namespace HotelBooker.Services.Interface
{
    public interface IBookingService
    {
        Task<BookingModel?> Create(BookingSaveModel saveModel);
        Task<BookingModel?> GetBookingByReference(string reference);
    }
}
