using Microsoft.EntityFrameworkCore;

namespace HotelBooker.Data.Entity
{
    [Index(nameof(BookingReference), IsUnique = true)]
    public class Booking
    {
        public int Id { get; set; }
        public string BookingReference { get; set; } // HBK-2025-JJJ777
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
        public int NumberOfGuests { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public ICollection<Payment> Payments { get; } = [];


    }
}
