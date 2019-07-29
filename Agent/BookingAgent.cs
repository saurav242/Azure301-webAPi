using Agent.Interface;
using Entity.Models;
using Repository.Interface;
using System.Collections.Generic;

namespace Agent
{
    public class BookingAgent : IBookingAgent
    {
        private readonly IRepositoryWrapper _repository;

        public BookingAgent(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public void CreateBooking(Booking booking)
        {
            _repository.Booking.CreateBooking(booking);
            _repository.Save();
        }

        public IEnumerable<Booking> GetBookingsByHotelID(int hotelID)
        {
            return _repository.Booking.GetBookingsByHotelID(hotelID);
        }

        public Booking GetBookingsByID(int bookingID)
        {
            return _repository.Booking.GetBookingsByID(bookingID);
        }

        public IEnumerable<Booking> GetBookingsByUserID(int UserID)
        {
            return _repository.Booking.GetBookingsByUserID(UserID);
        }
    }
}
