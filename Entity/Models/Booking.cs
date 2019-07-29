using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public partial class Booking
    {
        [Key]
        public int Id { get; set; }
        public int HotelRoomId { get; set; }
        public int ConsumerId { get; set; }
        public int NumberOfRoom { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BookingDate { get; set; }

        public virtual User Consumer { get; set; }
        public virtual HotelRoom HotelRoom { get; set; }
    }
}
