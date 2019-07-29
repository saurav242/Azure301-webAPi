using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateBooking(Booking booking)
        {
            Create(booking);
        }

        public IEnumerable<Booking> GetBookingsByHotelID(int hotelID)
        {
            return FindByCondition(book => book.HotelRoom.HotelId == hotelID).Include(x => x.HotelRoom);
        }

        public Booking GetBookingsByID(int bookingID)
        {
            return FindByCondition(book => book.Id == bookingID).Include(x => x.Consumer).Include(x => x.HotelRoom).FirstOrDefault();
        }

        public IEnumerable<Booking> GetBookingsByUserID(int userID)
        {
            return FindByCondition(book => book.ConsumerId == userID).Include(x => x.HotelRoom).Include(x => x.Consumer);
        }
    }
}
