﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyHotel;

#nullable disable

namespace MyHotel.Migrations
{
    [DbContext(typeof(MyHotelDbContext))]
    partial class MyHotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyHotel.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StaffId = 1,
                            email = "kien@gmail.com",
                            password = "kien123"
                        },
                        new
                        {
                            Id = 2,
                            StaffId = 2,
                            email = "long@gmail.com",
                            password = "long123"
                        },
                        new
                        {
                            Id = 3,
                            StaffId = 3,
                            email = "kiet@gmail.com",
                            password = "kiet123"
                        },
                        new
                        {
                            Id = 4,
                            StaffId = 4,
                            email = "jane.smith@gmail.com",
                            password = "jane123"
                        },
                        new
                        {
                            Id = 5,
                            StaffId = 5,
                            email = "jane.smith@gmail.com",
                            password = "john123"
                        });
                });

            modelBuilder.Entity("MyHotel.Models.BookingService", b =>
                {
                    b.Property<int>("BookingServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingServiceId"), 1L, 1);

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("StaffId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalMoney")
                        .HasColumnType("float");

                    b.HasKey("BookingServiceId");

                    b.ToTable("BookingServices");
                });

            modelBuilder.Entity("MyHotel.Models.BookingsRoom", b =>
                {
                    b.Property<int>("BookingRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingRoomId"), 1L, 1);

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<double?>("TotalMoney")
                        .HasColumnType("float");

                    b.HasKey("BookingRoomId");

                    b.ToTable("BookingsRooms");
                });

            modelBuilder.Entity("MyHotel.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "8kV5H@example.com",
                            FullName = "John Doe",
                            Gender = "Male",
                            IdCard = "071",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            FullName = "Jane Smith",
                            Gender = "Male",
                            IdCard = "072",
                            PhoneNumber = "9876543210"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "m.johnson@example.com",
                            FullName = "Michael Johnson",
                            Gender = "Male",
                            IdCard = "073",
                            PhoneNumber = "5551234567"
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emily.d@example.com",
                            FullName = "Emily Davis",
                            Gender = "Male",
                            IdCard = "074",
                            PhoneNumber = "7778889999"
                        },
                        new
                        {
                            CustomerId = 5,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dbrown@example.com",
                            FullName = "David Brown",
                            Gender = "Male",
                            IdCard = "075",
                            PhoneNumber = "1112223333"
                        },
                        new
                        {
                            CustomerId = 6,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sarah.w@example.com",
                            FullName = "Sarah Wilson",
                            Gender = "Male",
                            IdCard = "076",
                            PhoneNumber = "3334445555"
                        },
                        new
                        {
                            CustomerId = 7,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "c.lee@example.com",
                            FullName = "Christopher Lee",
                            Gender = "Male",
                            IdCard = "077",
                            PhoneNumber = "6667778888"
                        },
                        new
                        {
                            CustomerId = 8,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jessica.m@example.com",
                            FullName = "Jessica Martinez",
                            Gender = "Male",
                            IdCard = "078",
                            PhoneNumber = "9990001111"
                        },
                        new
                        {
                            CustomerId = 9,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "m.taylor@example.com",
                            FullName = "Matthew Taylor",
                            Gender = "Male",
                            IdCard = "079",
                            PhoneNumber = "2223334444"
                        },
                        new
                        {
                            CustomerId = 10,
                            Address = "123 Main St, Anytown",
                            Country = "USA",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "amanda.r@example.com",
                            FullName = "Amanda Rodriguez",
                            Gender = "Male",
                            IdCard = "081",
                            PhoneNumber = "4445556666"
                        });
                });

            modelBuilder.Entity("MyHotel.Models.DetailBookingService", b =>
                {
                    b.Property<int>("DBS_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DBS_Id"), 1L, 1);

                    b.Property<int>("BookingServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<double>("TotalMoney")
                        .HasColumnType("float");

                    b.HasKey("DBS_Id");

                    b.ToTable("DetailBookingServices");
                });

            modelBuilder.Entity("MyHotel.Models.DetailBookingsRoom", b =>
                {
                    b.Property<int>("DBR_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DBR_Id"), 1L, 1);

                    b.Property<int>("BookingRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<double>("TotalMoney")
                        .HasColumnType("float");

                    b.HasKey("DBR_Id");

                    b.ToTable("DetailBookingsRooms");
                });

            modelBuilder.Entity("MyHotel.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"), 1L, 1);

                    b.Property<DateTime?>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double?>("Moneys")
                        .HasColumnType("float");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("MyHotel.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            IsActive = false,
                            Name = "Room 101",
                            Price = 1000.0,
                            Type = "Single Room"
                        },
                        new
                        {
                            RoomId = 2,
                            IsActive = true,
                            Name = "Room 102",
                            Price = 1000.0,
                            Type = "Single Room"
                        },
                        new
                        {
                            RoomId = 3,
                            IsActive = true,
                            Name = "Room 103",
                            Price = 1500.0,
                            Type = "Double Room"
                        },
                        new
                        {
                            RoomId = 4,
                            IsActive = false,
                            Name = "Room 201",
                            Price = 1500.0,
                            Type = "Double Room"
                        },
                        new
                        {
                            RoomId = 5,
                            IsActive = false,
                            Name = "Room 202",
                            Price = 1500.0,
                            Type = "Double Room"
                        },
                        new
                        {
                            RoomId = 6,
                            IsActive = false,
                            Name = "Room 203",
                            Price = 1000.0,
                            Type = "Single Room"
                        },
                        new
                        {
                            RoomId = 7,
                            IsActive = false,
                            Name = "Room 301",
                            Price = 1000.0,
                            Type = "Single Room"
                        },
                        new
                        {
                            RoomId = 8,
                            IsActive = true,
                            Name = "Room 302",
                            Price = 2200.0,
                            Type = "Family Room"
                        },
                        new
                        {
                            RoomId = 9,
                            IsActive = false,
                            Name = "Room 303",
                            Price = 1000.0,
                            Type = "Single Room"
                        },
                        new
                        {
                            RoomId = 10,
                            IsActive = true,
                            Name = "Room 304",
                            Price = 2200.0,
                            Type = "Family Room"
                        });
                });

            modelBuilder.Entity("MyHotel.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            Name = "Bus",
                            Price = 100.0
                        },
                        new
                        {
                            ServiceId = 2,
                            Name = "Taxi",
                            Price = 100.0
                        },
                        new
                        {
                            ServiceId = 3,
                            Name = "Breakfast",
                            Price = 100.0
                        },
                        new
                        {
                            ServiceId = 4,
                            Name = "Lunch",
                            Price = 100.0
                        },
                        new
                        {
                            ServiceId = 5,
                            Name = "Dinner",
                            Price = 100.0
                        },
                        new
                        {
                            ServiceId = 6,
                            Name = "Beverage",
                            Price = 100.0
                        },
                        new
                        {
                            ServiceId = 7,
                            Name = "Food",
                            Price = 100.0
                        },
                        new
                        {
                            ServiceId = 8,
                            Name = "Taxi",
                            Price = 100.0
                        },
                        new
                        {
                            ServiceId = 9,
                            Name = "City Tour",
                            Price = 100.0
                        },
                        new
                        {
                            ServiceId = 10,
                            Name = "Meeting Room",
                            Price = 100.0
                        });
                });

            modelBuilder.Entity("MyHotel.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("StaffId");

                    b.ToTable("Staffs");

                    b.HasData(
                        new
                        {
                            StaffId = 1,
                            Address = "123 Main St, Anytown",
                            DOB = new DateTime(2003, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "kien@gmail.com",
                            FullName = "Trung Kien",
                            Gender = "male",
                            PhoneNumber = "3134567890",
                            Position = "manager",
                            Salary = 50000.0
                        },
                        new
                        {
                            StaffId = 2,
                            Address = "123 Main St, Anytown",
                            DOB = new DateTime(2003, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "long@gmail.com",
                            FullName = "Long Vu",
                            Gender = "male",
                            PhoneNumber = "4123567890",
                            Position = "manager",
                            Salary = 50000.0
                        },
                        new
                        {
                            StaffId = 3,
                            Address = "123 Main St, Anytown",
                            DOB = new DateTime(2003, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "kiet@gmail.com",
                            FullName = "Anh Kiet",
                            Gender = "male",
                            PhoneNumber = "5123467890",
                            Position = "manager",
                            Salary = 50000.0
                        },
                        new
                        {
                            StaffId = 4,
                            Address = "456 Elm St, Springfield",
                            DOB = new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@gmail.com",
                            FullName = "Jane Smith",
                            Gender = "female",
                            PhoneNumber = "9876543210",
                            Position = "receptionist",
                            Salary = 45000.0
                        },
                        new
                        {
                            StaffId = 5,
                            Address = "789 Oak St, Metro City",
                            DOB = new DateTime(1983, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@gmail.com",
                            FullName = "Michael Johnson",
                            Gender = "male",
                            PhoneNumber = "5551234567",
                            Position = "receptionist",
                            Salary = 40000.0
                        });
                });

            modelBuilder.Entity("MyHotel.Models.TempRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TempRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
