using Entity;
using Entity.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class HotelRoomRepository : RepositoryBase<HotelRoom>, IHotelRoomRepository
    {
        public HotelRoomRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<HotelRoom> GetRooms(int hotelID)
        {
          return  FindByCondition(room => room.HotelId == hotelID);
        }
    }
}
