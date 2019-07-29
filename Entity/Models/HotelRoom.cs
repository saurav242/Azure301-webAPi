using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public partial class HotelRoom
    {
        //public HotelRoom()
        //{
        //    Booking = new HashSet<Booking>();
        //}
        [Key]
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int NumberOfRoom { get; set; }
        public string RoomType { get; set; }
        public int NumOfPeople { get; set; }
        public int PriceRate { get; set; }

        //public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
