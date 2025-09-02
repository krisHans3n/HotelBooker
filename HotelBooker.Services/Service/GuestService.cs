using HotelBooker.Data;
using HotelBooker.Data.Models;
using HotelBooker.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelBooker.Services.Service
{
    public class GuestService : IGuestService
    {
        private readonly DataContext _context;
        public GuestService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<GuestModel>> GetAll()
        {
            var guests = await _context.Guests.Select(g => new GuestModel
            {
                Id = g.Id,
                FirstName = g.FirstName,
                LastName = g.LastName,
                PhoneNumber = g.PhoneNumber,
                Address = g.Address,
                Email = g.Email,
                DateOfBirth = g.DateOfBirth
            }).ToListAsync();

            return guests;
        }
    }
}
