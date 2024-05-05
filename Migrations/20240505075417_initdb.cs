using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotel.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingServices",
                columns: table => new
                {
                    BookingServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<double>(type: "float", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServices", x => x.BookingServiceId);
                });

            migrationBuilder.CreateTable(
                name: "BookingsRooms",
                columns: table => new
                {
                    BookingRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<double>(type: "float", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsRooms", x => x.BookingRoomId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "Date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DetailBookingServices",
                columns: table => new
                {
                    DBS_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailBookingServices", x => x.DBS_Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailBookingsRooms",
                columns: table => new
                {
                    DBR_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingRoomId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailBookingsRooms", x => x.DBR_Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Moneys = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "Date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "TempRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempRooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "StaffId", "email", "password" },
                values: new object[,]
                {
                    { 1, 1, "kien@gmail.com", "kien123" },
                    { 2, 2, "long@gmail.com", "long123" },
                    { 3, 3, "kiet@gmail.com", "kiet123" },
                    { 4, 4, "jane.smith@gmail.com", "jane123" },
                    { 5, 5, "jane.smith@gmail.com", "john123" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Country", "DOB", "Email", "FullName", "Gender", "IdCard", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "8kV5H@example.com", "John Doe", "Male", "071", "1234567890" },
                    { 2, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith", "Male", "072", "9876543210" },
                    { 3, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "m.johnson@example.com", "Michael Johnson", "Male", "073", "5551234567" },
                    { 4, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.d@example.com", "Emily Davis", "Male", "074", "7778889999" },
                    { 5, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "dbrown@example.com", "David Brown", "Male", "075", "1112223333" },
                    { 6, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.w@example.com", "Sarah Wilson", "Male", "076", "3334445555" },
                    { 7, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c.lee@example.com", "Christopher Lee", "Male", "077", "6667778888" },
                    { 8, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "jessica.m@example.com", "Jessica Martinez", "Male", "078", "9990001111" },
                    { 9, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "m.taylor@example.com", "Matthew Taylor", "Male", "079", "2223334444" },
                    { 10, "123 Main St, Anytown", "USA", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "amanda.r@example.com", "Amanda Rodriguez", "Male", "081", "4445556666" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "IsActive", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, false, "Room 101", 1000.0, "Single Room" },
                    { 2, true, "Room 102", 1000.0, "Single Room" },
                    { 3, true, "Room 103", 1500.0, "Double Room" },
                    { 4, false, "Room 201", 1500.0, "Double Room" },
                    { 5, false, "Room 202", 1500.0, "Double Room" },
                    { 6, false, "Room 203", 1000.0, "Single Room" },
                    { 7, false, "Room 301", 1000.0, "Single Room" },
                    { 8, true, "Room 302", 2200.0, "Family Room" },
                    { 9, false, "Room 303", 1000.0, "Single Room" },
                    { 10, true, "Room 304", 2200.0, "Family Room" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Bus", 100.0 },
                    { 2, "Taxi", 100.0 },
                    { 3, "Breakfast", 100.0 },
                    { 4, "Lunch", 100.0 },
                    { 5, "Dinner", 100.0 },
                    { 6, "Beverage", 100.0 },
                    { 7, "Food", 100.0 },
                    { 8, "Taxi", 100.0 },
                    { 9, "City Tour", 100.0 },
                    { 10, "Meeting Room", 100.0 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "Address", "DOB", "Email", "FullName", "Gender", "PhoneNumber", "Position", "Salary" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown", new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "kien@gmail.com", "Trung Kien", "male", "3134567890", "manager", 50000.0 },
                    { 2, "123 Main St, Anytown", new DateTime(2003, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "long@gmail.com", "Long Vu", "male", "4123567890", "manager", 50000.0 },
                    { 3, "123 Main St, Anytown", new DateTime(2003, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "kiet@gmail.com", "Anh Kiet", "male", "5123467890", "manager", 50000.0 },
                    { 4, "456 Elm St, Springfield", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@gmail.com", "Jane Smith", "female", "9876543210", "receptionist", 45000.0 },
                    { 5, "789 Oak St, Metro City", new DateTime(1983, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@gmail.com", "Michael Johnson", "male", "5551234567", "receptionist", 40000.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "BookingServices");

            migrationBuilder.DropTable(
                name: "BookingsRooms");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DetailBookingServices");

            migrationBuilder.DropTable(
                name: "DetailBookingsRooms");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "TempRooms");
        }
    }
}
