using HotelBooker.Data.Models;

namespace HotelBooker.Services.Interface
{
    public interface IGuestService
    {
        Task<IEnumerable<GuestModel>> GetAll();
    }
}
