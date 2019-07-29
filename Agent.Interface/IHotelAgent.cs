using Entity.Models;
using System.Collections.Generic;

namespace Agent.Interface
{
    public interface IHotelAgent
    {
        IEnumerable<Hotel> GetAllHotel();
        Hotel GetHotelByID(int hotelID);

        IEnumerable<Hotel> GetHotelByCity(string city);

        void CreateHotel(Hotel hotel);
    }
}
