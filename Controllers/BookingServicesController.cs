using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHotel;
using MyHotel.Models;
using MyHotel.Models.InputModel;

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
        [HttpGet("service")]
        public async Task<ActionResult<IEnumerable<TempService>>> GetRooms()
        {
            if (_context.TempServices == null)
            {
                return NotFound();
            }
            return await _context.TempServices.ToListAsync();
        }
        [HttpGet("service/{DBR_id}")]
        public async Task<ActionResult<IEnumerable<BookingService>>> GetAllBookingService(int DBR_id)
        {
            if (_context.BookingServices == null)
            {
                return NotFound();
            }
            var bookingService = await _context.BookingServices.Where(t => t.DBR_Id == DBR_id).ToListAsync();
            List<DetailBookingService> list = new List<DetailBookingService>();
            if (bookingService == null)
            {
                return NotFound();
            }
            else
            {
                foreach(var bookSV in bookingService)
                {
                    
                }
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

        [HttpPost("service/{id}")]
        public async Task<ActionResult> AddService(int id, [FromBody] TempServiceInputModel model)
        {
            var had = await _context.TempServices.FirstOrDefaultAsync(t => t.ServiceId == id);

            if(had == null)
            {
                TempService tempService = new();
                tempService.ServiceId = id;
                tempService.Name = model.name;
                tempService.Price = model.price;
                tempService.Amount = 1;
                _context.TempServices.Add(tempService);
            }
            else
            {
                had.Amount += 1;
                _context.Entry(had).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            
            return Ok();
        }

        [HttpDelete("service/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (_context.TempServices == null)
            {
                return NotFound();
            }
            var tempService = await _context.TempServices.FirstOrDefaultAsync(t => t.ServiceId == id);
            if (tempService == null)
            {
                return NotFound();
            }
            _context.TempServices.Remove(tempService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("service/all")]
        public IActionResult DeleteAll()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("DELETE FROM TempServices");
                return Ok("All data deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("detail-room-booking/{DBR_id}")]
        public async Task<ActionResult<BookingService>> PostBookingService(int DBR_id, int StaffId)
        {
            if (_context.BookingServices == null)
            {
                return Problem("Entity set 'MyHotelDbContext.BookingServices'  is null.");
            }

            BookingService bookingService = new();
            bookingService.DBR_Id = DBR_id;
            bookingService.CreateDate = DateTime.Now;
            bookingService.TotalMoney = 0;
            bookingService.StaffId = StaffId;

            _context.BookingServices.Add(bookingService);
            await _context.SaveChangesAsync();

            var tempBKService = await _context.BookingServices.FirstOrDefaultAsync(i => i.CreateDate == bookingService.CreateDate);
            if (tempBKService != null)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        double sum = 0;
                        foreach (var service in _context.TempServices)
                        {
                            DetailBookingService detailBookingService = new();
                            detailBookingService.BookingServiceId = tempBKService.BookingServiceId;
                            detailBookingService.ServiceId = service.ServiceId;
                            detailBookingService.Name = service.Name;
                            detailBookingService.Amount = service.Amount;
                            detailBookingService.CreateDate = DateTime.Now;

                            var ser = await _context.Services.FindAsync(service.ServiceId);
                            detailBookingService.TotalMoney = ser.Price * service.Amount;

                            sum += detailBookingService.TotalMoney;

                            _context.DetailBookingServices.Add(detailBookingService);
                            await _context.SaveChangesAsync();
                        }
                        await transaction.CommitAsync();

                        bookingService.TotalMoney = sum;
                        _context.Entry(bookingService).State = EntityState.Modified;

                        int bookingRoomId = _context.DetailBookingsRooms.Where(a => a.DBR_Id == DBR_id).Select(a => a.BookingRoomId).FirstOrDefault();
                        int invoiceId = _context.BookingsRooms.Where(b => b.BookingRoomId == bookingRoomId).Select(b => b.InvoiceId).FirstOrDefault();
                        var tempInvoice = await _context.Invoices.FindAsync(invoiceId);
                        tempInvoice.Moneys += sum;
                        _context.Entry(tempInvoice).State = EntityState.Modified;

                        await _context.SaveChangesAsync();
                        DeleteAll();
                    }
                    catch (Exception)
                    {
                        // Nếu có lỗi, rollback giao dịch
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }

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
