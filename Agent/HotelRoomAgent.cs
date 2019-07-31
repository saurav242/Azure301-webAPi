using Agent.Interface;
using Entity.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repository.Interface;
using System;
using System.Collections.Generic;

namespace Agent
{
    public class HotelRoomAgent : IHotelRoomAgent
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IDistributedCache _cache;


        public HotelRoomAgent(IRepositoryWrapper repository, IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;

        }

        public IEnumerable<HotelRoom> GetRoomForHotel(int hotelID)
        {

            IEnumerable<HotelRoom> roomForHotel;

            var cachedCookies = _cache.GetString(hotelID + "RoomForHotel");

            if (!string.IsNullOrEmpty(cachedCookies))
            {
                roomForHotel = JsonConvert.DeserializeObject<IEnumerable<HotelRoom>>(cachedCookies);
            }
            else
            {
                roomForHotel = _repository.HotelRoom.GetRooms(hotelID);
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
                options.SetAbsoluteExpiration(new TimeSpan(0, 0, 15));

                _cache.SetString(hotelID + "GetRoomForHotel", JsonConvert.SerializeObject(hotelID), options);
            }

            return roomForHotel;            
        }
    }
}
