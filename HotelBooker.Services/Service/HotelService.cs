using HotelBooker.Data;
using HotelBooker.Data.Models;
using HotelBooker.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelBooker.Services.Service
{
    public class HotelService : IHotelService
    {
        private readonly DataContext _context;

        public HotelService(DataContext dataContext)
        {
            _context = dataContext;

        }

        public async Task<HotelModel?> GetHotelByName(string name)
        {
            var hotel = await _context.Hotels.Where(x => x.Name == name).FirstOrDefaultAsync();

            if (hotel != null)
            {
                return new HotelModel()
                {
                    Name = hotel.Name,
                    CheckIn = hotel.CheckIn,
                    CheckOut = hotel.CheckOut
                };
            }

            return null;
        }
    }
}
