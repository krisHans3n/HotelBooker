
namespace HotelBooker.Data.Entity
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateOnly PaymentDate {  get; set; }
        public string PaymentMethod { get; set; }
        public bool Status { get; set; }
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
