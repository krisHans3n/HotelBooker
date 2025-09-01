
namespace HotelBooker.Data.Models.Booking
{
    public class BookingModel
    {
        public required string BookingReference { get; set; }
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
        public decimal TotalPrice
        {
            get
            {                
                if (Room?.PricePerNight == null)
                {
                    return 0;
                }

                int numberOfNights = CheckOut.DayNumber - CheckIn.DayNumber;

                return numberOfNights * Room.PricePerNight;
            }
        }
        public int NumberOfGuests { get; set; }
        public RoomModel? Room { get; set; }
    }
}
