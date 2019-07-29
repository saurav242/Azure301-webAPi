using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
   public interface IBookingRepository : IRepositoryBase<Booking>
    {
        Booking GetBookingsByID(int bookingID);


        IEnumerable<Booking> GetBookingsByHotelID(int hotelID);
        IEnumerable<Booking> GetBookingsByUserID(int UserID);

        void CreateBooking(Booking booking);
    }
}
