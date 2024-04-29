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
    public class DetailBookingsRoomsController : ControllerBase
    {
        private readonly MyHotelDbContext _context;

        public DetailBookingsRoomsController(MyHotelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailBookingsRoom>>> GetDetailBookingsRooms()
        {
          if (_context.DetailBookingsRooms == null)
          {
              return NotFound();
          }
            return await _context.DetailBookingsRooms.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailBookingsRoom>> GetDetailBookingsRoom(int id)
        {
          if (_context.DetailBookingsRooms == null)
          {
              return NotFound();
          }
            var detailBookingsRoom = await _context.DetailBookingsRooms.FindAsync(id);

            if (detailBookingsRoom == null)
            {
                return NotFound();
            }

            return detailBookingsRoom;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailBookingsRoom(int id, DetailBookingsRoom detailBookingsRoom)
        {
            if (id != detailBookingsRoom.DBR_Id)
            {
                return BadRequest();
            }

            _context.Entry(detailBookingsRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailBookingsRoomExists(id))
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
        public async Task<ActionResult<DetailBookingsRoom>> PostDetailBookingsRoom(DetailBookingsRoom detailBookingsRoom)
        {
          if (_context.DetailBookingsRooms == null)
          {
              return Problem("Entity set 'MyHotelDbContext.DetailBookingsRooms'  is null.");
          }
            _context.DetailBookingsRooms.Add(detailBookingsRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailBookingsRoom", new { id = detailBookingsRoom.DBR_Id }, detailBookingsRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailBookingsRoom(int id)
        {
            if (_context.DetailBookingsRooms == null)
            {
                return NotFound();
            }
            var detailBookingsRoom = await _context.DetailBookingsRooms.FindAsync(id);
            if (detailBookingsRoom == null)
            {
                return NotFound();
            }

            _context.DetailBookingsRooms.Remove(detailBookingsRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailBookingsRoomExists(int id)
        {
            return (_context.DetailBookingsRooms?.Any(e => e.DBR_Id == id)).GetValueOrDefault();
        }
    }
}
