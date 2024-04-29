using Microsoft.EntityFrameworkCore;
using MyHotel.Models;

namespace MyHotel
{
    public class MyHotelDbContext : DbContext
    {
        public MyHotelDbContext(DbContextOptions<MyHotelDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }
        public DbSet<BookingsRoom> BookingsRooms { get; set; }
        public DbSet<DetailBookingService> DetailBookingServices { get; set; }
        public DbSet<DetailBookingsRoom> DetailBookingsRooms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
