using Agent.Interface;
using Entity.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Agent
{
    public class HotelAgent : IHotelAgent
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IDistributedCache _cache;

        public HotelAgent(IRepositoryWrapper repository, IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public void CreateHotel(Hotel hotel)
        {
            _repository.Hotel.CreateHotel(hotel);
            _repository.Save();
        }

        public IEnumerable<Hotel> GetAllHotel()
        {
            IEnumerable<Hotel> hotel;

            var cachedCookies = _cache.GetString("allhotelcookies");

            if (!string.IsNullOrEmpty(cachedCookies))
            {
                hotel = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(cachedCookies);
            }
            else
            {
                hotel = _repository.Hotel.GetAllHotels();
                _cache.SetString("allhotelcookies", JsonConvert.SerializeObject(hotel));
            }
            return hotel;
        }

        public IEnumerable<Hotel> GetHotelByCity(string city)
        {
            IEnumerable<Hotel> hotelByCity;


            if (string.IsNullOrEmpty(city))
            {
                return null;
            }
            else
            {

                var cachedCookies = _cache.GetString(city + "hotelcookies");

                if (!string.IsNullOrEmpty(cachedCookies))
                {
                    hotelByCity = JsonConvert.DeserializeObject<IEnumerable<Hotel>>(cachedCookies);
                }
                else
                {
                    hotelByCity = _repository.Hotel.GetHotelByCity(city);
                    _cache.SetString(city + "hotelcookies", JsonConvert.SerializeObject(hotelByCity));
                }

                return hotelByCity;
            }
        }

        public Hotel GetHotelByID(int hotelID)
        {

            Hotel hotelByID;

            var cachedCookies = _cache.GetString(hotelID + "hotelcookies");

            if (!string.IsNullOrEmpty(cachedCookies))
            {
                hotelByID = JsonConvert.DeserializeObject<Hotel>(cachedCookies);
            }
            else
            {
                hotelByID = _repository.Hotel.GetHotelById(hotelID).FirstOrDefault();

                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
                options.SetAbsoluteExpiration(new TimeSpan(0, 0, 15));

                _cache.SetString(hotelID + "hotelcookies", JsonConvert.SerializeObject(hotelByID), options);
            }

            return hotelByID;

        }
    }
}
