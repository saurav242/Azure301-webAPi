using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public partial class User
    {
        //public User()
        //{
        //    Booking = new HashSet<Booking>();
        //}
        [Key]
        public int Id { get; set; }
        public string Idcard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Nationality { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
