using System.ComponentModel.DataAnnotations;

namespace HotelBooker.Data.Entity
{
    public class Room
    {
        public int ID { get; set; }
        public int RoomNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<Booking> Bookings { get; } = [];
        [Timestamp]
        public byte[] Version { get; set; }
    }
}
