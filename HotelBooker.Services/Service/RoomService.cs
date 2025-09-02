using HotelBooker.Data;
using HotelBooker.Data.Models;
using HotelBooker.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelBooker.Services.Service
{
    public class RoomService : IRoomService
    {
        private readonly DataContext _context;
        public RoomService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomModel?>> GetAll()
        {
            var rooms = await _context.Rooms
                .Include(x => x.Hotel)
                .Include(x => x.RoomType)
                .ToListAsync();

            var result = new List<RoomModel>();

            foreach (var room in rooms)
            {
                result.Add(new RoomModel()
                {
                    Id = room.ID,
                    RoomNumber = room.RoomNumber,
                    PricePerNight = room.PricePerNight,
                    Capacity = room.Capacity,
                    Hotel = new HotelModel()
                    {
                        Name = room.Hotel.Name,
                        CheckIn = room.Hotel.CheckIn,
                        CheckOut = room.Hotel.CheckOut,
                    },
                    RoomType = new RoomTypeModel()
                    {
                        Name = room.RoomType.Name,
                    }
                });
            }

            return result;
        }
        public async Task<IEnumerable<RoomModel?>> GetAvailableRooms(DateOnly from, DateOnly to)
        {
            var rooms = await _context.Rooms
                .Where(x => !x.Bookings.Any(y => y.CheckIn <= to && y.CheckOut >= from))
                .Select(r => new RoomModel
                {
                    Id = r.ID,
                    RoomNumber = r.RoomNumber,
                    PricePerNight = r.PricePerNight,
                    Capacity = r.Capacity,
                    Hotel = new HotelModel
                    {
                        Name = r.Hotel.Name,
                        CheckIn = r.Hotel.CheckIn,
                        CheckOut = r.Hotel.CheckOut
                    },
                    RoomType = new RoomTypeModel
                    {
                        Name = r.RoomType.Name
                    }
                })
                .ToListAsync();

            return rooms;
        }
    }
}
