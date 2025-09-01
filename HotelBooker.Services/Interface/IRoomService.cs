using HotelBooker.Data.Models;

namespace HotelBooker.Services.Interface
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomModel?>> GetAll();
        Task<IEnumerable<RoomModel?>> GetAvailableRooms(DateOnly from, DateOnly to);
    }
}
