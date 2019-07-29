using Entity.Models;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IHotelRepository : IRepositoryBase<Hotel>
    {
        IEnumerable<Hotel> GetAllHotels();
        IEnumerable<Hotel> GetHotelById(int hotelID);

        IEnumerable<Hotel> GetHotelByCity(string city);

        void CreateHotel(Hotel hotel);
    }

}
