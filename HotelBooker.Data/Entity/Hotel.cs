
namespace HotelBooker.Data.Entity
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeOnly CheckIn { get; set; }
        public TimeOnly CheckOut { get; set; }
        public ICollection<Room> Rooms { get; } = [];
    }
}
