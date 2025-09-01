
namespace HotelBooker.Data.Models
{
    public class RoomModel
    {
        public int? Id { get; set; }
        public int RoomNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public HotelModel Hotel { get; set; }
        public RoomTypeModel RoomType { get; set; }
    }
}
