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
            builder.Entity<Staff>().HasData(
                new Staff { StaffId = 1, FullName = "Trung Kien", PhoneNumber = "3134567890", Email = "kien@example.com", DOB = DateTime.Parse("2003-12-03"), Address = "123 Main St, Anytown", Gender = "male", Position = "manager", Salary = 50000 },
                new Staff { StaffId = 2, FullName = "Long Vu", PhoneNumber = "4123567890", Email = "long@example.com", DOB = DateTime.Parse("2003-02-02"), Address = "123 Main St, Anytown", Gender = "male", Position = "manager", Salary = 50000 },
                new Staff { StaffId = 3, FullName = "Anh Kiet", PhoneNumber = "5123467890", Email = "kiet@example.com", DOB = DateTime.Parse("2003-03-04"), Address = "123 Main St, Anytown", Gender = "male", Position = "manager", Salary = 50000 },
                new Staff { StaffId = 4, FullName = "Jane Smith", PhoneNumber = "9876543210", Email = "jane.smith@example.com", DOB = DateTime.Parse("1985-05-15"), Address = "456 Elm St, Springfield", Gender = "female", Position = "receptionist", Salary = 45000 },
                new Staff { StaffId = 5, FullName = "Michael Johnson", PhoneNumber = "5551234567", Email = "jane.smith@example.com", DOB = DateTime.Parse("1983-09-22"), Address = "789 Oak St, Metro City", Gender = "male", Position = "receptionist", Salary = 40000 }
            );

            builder.Entity<Account>().HasData(
                new Account { Id = 1, email = "kien@example.com", password = "kien123", StaffId = 1},
                new Account { Id = 2, email = "long@example.com", password = "long123", StaffId = 2 },
                new Account { Id = 3, email = "kiet@example.com", password = "kiet123" , StaffId = 3 },
                new Account { Id = 4, email = "jane.smith@example.com", password = "jane123" , StaffId = 4 },
                new Account { Id = 5, email = "jane.smith@example.com", password = "john123" , StaffId = 5 }
            );

            builder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, IdCard = "071",FullName = "John Doe", PhoneNumber = "1234567890", Email = "8kV5H@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" },
                new Customer { CustomerId = 2, IdCard = "072", FullName = "Jane Smith", PhoneNumber = "9876543210", Email = "jane.smith@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" },
                new Customer { CustomerId = 3, IdCard = "073", FullName = "Michael Johnson", PhoneNumber = "5551234567", Email = "m.johnson@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" },
                new Customer { CustomerId = 4, IdCard = "074", FullName = "Emily Davis", PhoneNumber = "7778889999", Email = "emily.d@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" },
                new Customer { CustomerId = 5, IdCard = "075", FullName = "David Brown", PhoneNumber = "1112223333", Email = "dbrown@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" },
                new Customer { CustomerId = 6, IdCard = "076", FullName = "Sarah Wilson", PhoneNumber = "3334445555", Email = "sarah.w@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" },
                new Customer { CustomerId = 7, IdCard = "077", FullName = "Christopher Lee", PhoneNumber = "6667778888", Email = "c.lee@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" },
                new Customer { CustomerId = 8, IdCard = "078", FullName = "Jessica Martinez", PhoneNumber = "9990001111", Email = "jessica.m@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" },
                new Customer { CustomerId = 9, IdCard = "079", FullName = "Matthew Taylor", PhoneNumber = "2223334444", Email = "m.taylor@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" },
                new Customer { CustomerId = 10, IdCard = "081", FullName = "Amanda Rodriguez", PhoneNumber = "4445556666", Email = "amanda.r@example.com", Gender = "Male", DOB = DateTime.Parse("2003-12-03"), Country = "USA", Address = "123 Main St, Anytown" }
            );

            builder.Entity<Room>().HasData(
                new Room { RoomId = 1, Name = "Room 101", IsActive = false, Price = 1000, Type = "Single Room"},
                new Room { RoomId = 2, Name = "Room 102", IsActive = true, Price = 1000, Type = "Single Room" },
                new Room { RoomId = 3, Name = "Room 103", IsActive = true, Price = 1500, Type = "Double Room" },
                new Room { RoomId = 4, Name = "Room 201", IsActive = false, Price = 1500, Type = "Double Room" },
                new Room { RoomId = 5, Name = "Room 202", IsActive = false, Price = 1500, Type = "Double Room" },
                new Room { RoomId = 6, Name = "Room 203", IsActive = false, Price = 1000, Type = "Single Room" },
                new Room { RoomId = 7, Name = "Room 301", IsActive = false, Price = 1000, Type = "Single Room" },
                new Room { RoomId = 8, Name = "Room 302", IsActive = true, Price = 2200, Type = "Family Room" },
                new Room { RoomId = 9, Name = "Room 303", IsActive = false, Price = 1000, Type = "Single Room" },
                new Room { RoomId = 10, Name = "Room 304", IsActive = true, Price = 2200, Type = "Family Room" }
            );


            builder.Entity<Service>().HasData(
                new Service { ServiceId = 1, Name = "Bus", Price = 100 },
                new Service { ServiceId = 2, Name = "Taxi", Price = 100 },
                new Service { ServiceId = 3, Name = "Breakfast", Price = 100 },
                new Service { ServiceId = 4, Name = "Lunch", Price = 100 },
                new Service { ServiceId = 5, Name = "Dinner", Price = 100 },
                new Service { ServiceId = 6, Name = "Beverage", Price = 100 },
                new Service { ServiceId = 7, Name = "Food", Price = 100 },
                new Service { ServiceId = 8, Name = "Taxi", Price = 100 },
                new Service { ServiceId = 9, Name = "City Tour", Price = 100 },
                new Service { ServiceId = 10, Name = "Meeting Room", Price = 100 }
            );
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
