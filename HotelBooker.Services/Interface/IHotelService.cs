using HotelBooker.Data.Models;

namespace HotelBooker.Services.Interface
{
    public interface IHotelService
    {
        Task<HotelModel?> GetHotelByName(string name);
    }
}
