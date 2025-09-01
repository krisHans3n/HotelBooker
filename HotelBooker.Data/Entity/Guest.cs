﻿
namespace HotelBooker.Data.Entity
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Booking> Bookings { get; } = [];

    }
}
