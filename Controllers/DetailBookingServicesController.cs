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
    public class DetailBookingServicesController : ControllerBase
    {
        private readonly MyHotelDbContext _context;

        public DetailBookingServicesController(MyHotelDbContext context)
        {
            _context = context;
        }

        // GET: api/DetailBookingServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailBookingService>>> GetDetailBookingServices()
        {
          if (_context.DetailBookingServices == null)
          {
              return NotFound();
          }
            return await _context.DetailBookingServices.ToListAsync();
        }

        // GET: api/DetailBookingServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailBookingService>> GetDetailBookingService(int id)
        {
          if (_context.DetailBookingServices == null)
          {
              return NotFound();
          }
            var detailBookingService = await _context.DetailBookingServices.FindAsync(id);

            if (detailBookingService == null)
            {
                return NotFound();
            }

            return detailBookingService;
        }

        // PUT: api/DetailBookingServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailBookingService(int id, DetailBookingService detailBookingService)
        {
            if (id != detailBookingService.DBS_Id)
            {
                return BadRequest();
            }

            _context.Entry(detailBookingService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailBookingServiceExists(id))
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

        // POST: api/DetailBookingServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetailBookingService>> PostDetailBookingService(DetailBookingService detailBookingService)
        {
          if (_context.DetailBookingServices == null)
          {
              return Problem("Entity set 'MyHotelDbContext.DetailBookingServices'  is null.");
          }
            _context.DetailBookingServices.Add(detailBookingService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailBookingService", new { id = detailBookingService.DBS_Id }, detailBookingService);
        }

        // DELETE: api/DetailBookingServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailBookingService(int id)
        {
            if (_context.DetailBookingServices == null)
            {
                return NotFound();
            }
            var detailBookingService = await _context.DetailBookingServices.FindAsync(id);
            if (detailBookingService == null)
            {
                return NotFound();
            }

            _context.DetailBookingServices.Remove(detailBookingService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailBookingServiceExists(int id)
        {
            return (_context.DetailBookingServices?.Any(e => e.DBS_Id == id)).GetValueOrDefault();
        }
    }
}
