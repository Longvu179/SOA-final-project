using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHotel;
using MyHotel.Models;
using MyHotel.Models.ViewModel;

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly MyHotelDbContext _context;

        public RoomsController(MyHotelDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        //{
        //  if (_context.Rooms == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Rooms.ToListAsync();
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomViewModel>>> GetRooms([FromForm] DateTime checkDate)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var rooms = await _context.Rooms.ToListAsync();
            var bookingrooms = await _context.DetailBookingsRooms.Where(b =>
                    checkDate >= b.CheckInDate && checkDate < b.CheckOutDate).ToListAsync();

            //foreach (var room in rooms)
            //{
            //    foreach (var bookingroom in bookingrooms)
            //    {
            //        if(room.RoomId == bookingroom.RoomId)
            //        {
            //            RoomViewModel newRoom = new();
            //            newRoom.DBR_Id = bookingroom.DBR_Id;
            //            newRoom.RoomId = room.RoomId;
            //            newRoom.Name = room.Name;
            //            newRoom.Type = room.Type;

            //            var booking = await _context.BookingsRooms.FindAsync(bookingroom.BookingRoomId);
            //            var invoice = await _context.Invoices.FindAsync(booking.InvoiceId);
            //            var customer = await _context.Customers.FindAsync(invoice.CustomerId);

            //            newRoom.CustomerName = customer.FullName;
            //            newRoom.IsBooking = true;
            //            newRoom.Days = (bookingroom.CheckOutDate - bookingroom.CheckInDate).Days;

            //            listRoom.Add(newRoom);
            //        }
            //        else
            //        {
            //            RoomViewModel newRoom = new();
            //            newRoom.RoomId = room.RoomId;
            //            newRoom.Name = room.Name;
            //            newRoom.Type = room.Type;
            //            newRoom.IsBooking = false;
            //            listRoom.Add(newRoom);
            //        }
            //    }
            //    if(bookingrooms.Count == 0)
            //    {
            //        RoomViewModel newRoom = new();
            //        newRoom.RoomId = room.RoomId;
            //        newRoom.Name = room.Name;
            //        newRoom.Type = room.Type;
            //        newRoom.IsBooking = false;
            //        listRoom.Add(newRoom);
            //    }
            //}
            var roomViewModels = from room in rooms select new RoomViewModel
                {
                    RoomId = room.RoomId,
                    Name = room.Name,
                    Type = room.Type,
                    DBR_Id = (from bookingroom in bookingrooms
                              where bookingroom.RoomId == room.RoomId
                              select bookingroom.DBR_Id).FirstOrDefault(),
                    IsBooking = bookingrooms.Any(b => b.RoomId == room.RoomId),
                        CustomerName = (from bookingroom in bookingrooms
                                        join booking in _context.BookingsRooms on bookingroom.BookingRoomId equals booking.BookingRoomId
                                        join invoice in _context.Invoices on booking.InvoiceId equals invoice.InvoiceId
                                        join customer in _context.Customers on invoice.CustomerId equals customer.CustomerId
                                        where bookingroom.RoomId == room.RoomId
                                        select customer.FullName).FirstOrDefault(),
                        Days = (from bookingroom in bookingrooms
                                where bookingroom.RoomId == room.RoomId
                                select (bookingroom.CheckOutDate - bookingroom.CheckInDate).Days).FirstOrDefault()
                };

            return Ok(roomViewModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(string id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.RoomId)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
          if (_context.Rooms == null)
          {
              return Problem("Entity set 'MyHotelDbContext.Rooms'  is null.");
          }
            _context.Rooms.Add(room);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomExists(room.RoomId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoom", new { id = room.RoomId }, room);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(string id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return (_context.Rooms?.Any(e => e.RoomId == id)).GetValueOrDefault();
        }
    }
}
