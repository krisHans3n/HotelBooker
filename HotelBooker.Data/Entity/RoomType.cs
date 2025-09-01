
namespace HotelBooker.Data.Entity
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Room> Rooms { get; } = [];
    }
}
