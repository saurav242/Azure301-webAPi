using Entity.Models;
using Microsoft.EntityFrameworkCore;


namespace Entity
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<Booking> Booking { get; set; }


    }
}