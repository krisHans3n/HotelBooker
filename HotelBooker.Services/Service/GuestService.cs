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
        public async Task<IEnumerable<GuestModel>> GetAll()
        {
            var guests = await _context.Guests.ToListAsync();

            var result = new List<GuestModel>();

            foreach (var guest in guests)
            {
                result.Add(new GuestModel()
                {
                    Id = guest.Id,
                    FirstName = guest.FirstName,
                    LastName = guest.LastName,
                    PhoneNumber = guest.PhoneNumber,
                    Address = guest.Address,
                    Email = guest.Email,
                    DateOfBirth = guest.DateOfBirth,
                });
            }

            return result;
        }
    }
}
