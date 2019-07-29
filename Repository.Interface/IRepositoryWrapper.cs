using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IHotelRepository Hotel { get; }
        IHotelRoomRepository HotelRoom{get; }

        IBookingRepository Booking { get; }

        void Save();
    }
}
