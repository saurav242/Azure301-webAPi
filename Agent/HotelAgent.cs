using Agent.Interface;
using Entity.Models;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Agent
{
    public class HotelAgent : IHotelAgent
    {
        private readonly IRepositoryWrapper _repository;

        public HotelAgent(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public void CreateHotel(Hotel hotel)
        {
            _repository.Hotel.CreateHotel(hotel);
            _repository.Save();
        }

        public IEnumerable<Hotel> GetAllHotel()
        {
            var hotel = _repository.Hotel.GetAllHotels();
            return hotel;
        }

        public IEnumerable<Hotel> GetHotelByCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return null;
            }
            else
            {
                return _repository.Hotel.GetHotelByCity(city);
            }
        }

        public Hotel GetHotelByID(int hotelID)
        {
            return _repository.Hotel.GetHotelById(hotelID).FirstOrDefault();
        }
    }
}
