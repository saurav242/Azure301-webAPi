using Agent.Interface;
using Entity.Models;
using Repository.Interface;
using System.Collections.Generic;

namespace Agent
{
    public class HotelRoomAgent : IHotelRoomAgent
    {
        private readonly IRepositoryWrapper _repository;

        public HotelRoomAgent(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IEnumerable<HotelRoom> GetRoomForHotel(int hotelID)
        {
            return _repository.HotelRoom.GetRooms(hotelID);
        }
    }
}
