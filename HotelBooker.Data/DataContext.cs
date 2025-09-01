using HotelBooker.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooker.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
