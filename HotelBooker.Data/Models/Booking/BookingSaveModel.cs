
namespace HotelBooker.Data.Models.Booking
{
    public class BookingSaveModel
    {
        public string BookingReference { get; set; }
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
    }
}
