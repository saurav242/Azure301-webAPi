using Entity;
using Repository.Interface;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private RepositoryContext _repoContext;
        private IUserRepository _user;
        private IHotelRepository _hotel;
        private IBookingRepository _booking;
        private IHotelRoomRepository _hotelRoom;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public IHotelRepository Hotel
        {
            get
            {
                if (_hotel == null)
                {
                    _hotel = new HotelRepository(_repoContext);
                }

                return _hotel;
            }
        }

        public IHotelRoomRepository HotelRoom
        {
            get
            {
                if (_hotelRoom == null)
                {
                    _hotelRoom = new HotelRoomRepository(_repoContext);
                }

                return _hotelRoom;
            }
        }

        public IBookingRepository Booking
        {
            get
            {
                if (_booking == null)
                {
                    _booking = new BookingRepository(_repoContext);
                }

                return _booking;
            }
        }


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }

}