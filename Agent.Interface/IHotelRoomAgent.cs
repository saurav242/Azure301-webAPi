using Entity.Models;
using System.Collections.Generic;

namespace Agent.Interface
{
    public interface IHotelRoomAgent
    {


        IEnumerable<HotelRoom> GetRoomForHotel(int hotelID);

    }
}
