using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IHotelRoomRepository
    {
        IEnumerable<HotelRoom> GetRooms(int hotelID);
    }
}
