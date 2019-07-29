using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {
        public HotelRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateHotel(Hotel hotel)
        {
            Create(hotel);
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return FindAll().OrderBy(ht => ht.Name).ToList();
        }

        public IEnumerable<Hotel> GetHotelByCity(string city)
        {
            return FindByCondition(htl => htl.City == city).ToList();
        }

        public IEnumerable<Hotel> GetHotelById(int hotelID)
        {
            return FindByCondition((htl => htl.Id == hotelID)).Include(x => x.HotelRoom).Include(x=>x.Booking);
        }
    }
}
