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
    public class BookingServicesController : ControllerBase
    {
        private readonly MyHotelDbContext _context;

        public BookingServicesController(MyHotelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingService>>> GetBookingServices()
        {
          if (_context.BookingServices == null)
          {
              return NotFound();
          }
            return await _context.BookingServices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingService>> GetBookingService(int id)
        {
          if (_context.BookingServices == null)
          {
              return NotFound();
          }
            var bookingService = await _context.BookingServices.FindAsync(id);

            if (bookingService == null)
            {
                return NotFound();
            }

            return bookingService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingService(int id, BookingService bookingService)
        {
            if (id != bookingService.BookingServiceId)
            {
                return BadRequest();
            }

            _context.Entry(bookingService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingServiceExists(id))
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
        public async Task<ActionResult<BookingService>> PostBookingService(BookingService bookingService)
        {
          if (_context.BookingServices == null)
          {
              return Problem("Entity set 'MyHotelDbContext.BookingServices'  is null.");
          }
            _context.BookingServices.Add(bookingService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingService", new { id = bookingService.BookingServiceId }, bookingService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingService(int id)
        {
            if (_context.BookingServices == null)
            {
                return NotFound();
            }
            var bookingService = await _context.BookingServices.FindAsync(id);
            if (bookingService == null)
            {
                return NotFound();
            }

            _context.BookingServices.Remove(bookingService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingServiceExists(int id)
        {
            return (_context.BookingServices?.Any(e => e.BookingServiceId == id)).GetValueOrDefault();
        }
    }
}
