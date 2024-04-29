using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHotel;
using MyHotel.Models;

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsRoomsController : ControllerBase
    {
        private readonly MyHotelDbContext _context;

        public BookingsRoomsController(MyHotelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingsRoom>>> GetBookingsRooms()
        {
          if (_context.BookingsRooms == null)
          {
              return NotFound();
          }
            return await _context.BookingsRooms.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingsRoom>> GetBookingsRoom(int id)
        {
          if (_context.BookingsRooms == null)
          {
              return NotFound();
          }
            var bookingsRoom = await _context.BookingsRooms.FindAsync(id);

            if (bookingsRoom == null)
            {
                return NotFound();
            }

            return bookingsRoom;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingsRoom(int id, BookingsRoom bookingsRoom)
        {
            if (id != bookingsRoom.BookingRoomId)
            {
                return BadRequest();
            }

            _context.Entry(bookingsRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingsRoomExists(id))
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
        public async Task<ActionResult<BookingsRoom>> PostBookingsRoom(BookingsRoom bookingsRoom, DetailBookingsRoom detailBookingsRoom)
        {
          if (_context.BookingsRooms == null)
          {
              return Problem("Entity set 'MyHotelDbContext.BookingsRooms'  is null.");
          }
            _context.BookingsRooms.Add(bookingsRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingsRoom", new { id = bookingsRoom.BookingRoomId }, bookingsRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingsRoom(int id)
        {
            if (_context.BookingsRooms == null)
            {
                return NotFound();
            }
            var bookingsRoom = await _context.BookingsRooms.FindAsync(id);
            if (bookingsRoom == null)
            {
                return NotFound();
            }

            _context.BookingsRooms.Remove(bookingsRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingsRoomExists(int id)
        {
            return (_context.BookingsRooms?.Any(e => e.BookingRoomId == id)).GetValueOrDefault();
        }
    }
}
