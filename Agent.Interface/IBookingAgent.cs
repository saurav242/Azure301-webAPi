using Entity.Models;
using System.Collections.Generic;

namespace Agent.Interface
{
    public interface IBookingAgent
    {

        IEnumerable<Booking> GetBookingsByHotelID(int hotelID);
        IEnumerable<Booking> GetBookingsByUserID(int UserID);

        void CreateBooking(Booking booking);
        Booking GetBookingsByID(int bookingID);

    }
}
