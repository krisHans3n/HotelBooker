using HotelBooker.Data.Models;

namespace HotelBooker.Services.Interface
{
    public interface IGuestService
    {
        Task<List<GuestModel>> GetAll();
    }
}
