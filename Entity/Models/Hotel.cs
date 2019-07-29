using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public partial class Hotel
    {
        //public Hotel()
        //{
        //    Booking = new HashSet<Booking>();
        //    HotelRoom = new HashSet<HotelRoom>();
        //}
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public int PhoneNumber { get; set; }
        public bool FreeParking { get; set; }
        public bool FreeWifi { get; set; }
        public bool AirConditioning { get; set; }
        public bool LiftAccess { get; set; }
        public bool Restaurant { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<HotelRoom> HotelRoom { get; set; }
    }
}
