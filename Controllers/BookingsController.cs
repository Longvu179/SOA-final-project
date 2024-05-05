using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHotel.Models;
using MyHotel.Models.InputModel;

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly MyHotelDbContext _context;
        public BookingsController(MyHotelDbContext context)
        {
            _context = context;
        }

        [HttpGet("room")]
        public async Task<ActionResult<IEnumerable<TempRoom>>> GetRooms()
        {
            if (_context.TempRooms == null)
            {
                return NotFound();
            }
            return await _context.TempRooms.ToListAsync();
        }

        [HttpPost("room/{id}")]
        public async Task<ActionResult> AddRoom(int id, [FromBody] CheckIn_OutDate check)
        {
            var room = await _context.Rooms.FindAsync(id);
            var existedTempRoom = await _context.TempRooms.FirstOrDefaultAsync(t => t.RoomId == id);
            if (existedTempRoom != null)
            {
                return Conflict("Room already booked");
            }
            TempRoom tempRoom = new();
            if (room != null)
            { 

                tempRoom.RoomId = id;
                tempRoom.Name = room.Name;
                tempRoom.Price = room.Price;
                tempRoom.CheckInDate = check.CheckInDate;
                tempRoom.CheckOutDate = check.CheckOutDate;
                tempRoom.IsActive = room.IsActive;
                tempRoom.Type = room.Type;
            }
            _context.TempRooms.Add(tempRoom);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("room/{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (_context.TempRooms == null)
            {
                return NotFound();
            }
            var tempRoom = await _context.TempRooms.FirstOrDefaultAsync(t => t.RoomId == id);
            if (tempRoom == null)
            {
                return NotFound();
            }

            _context.TempRooms.Remove(tempRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("room/all")]
        public IActionResult DeleteAll()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("DELETE FROM TempRooms");
                return Ok("All data deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("room/availble")]
        public async Task<ActionResult<IEnumerable<Room>>> GetActiveRooms([FromBody] CheckIn_OutDate check)
        {
            var existingBooking = await _context.DetailBookingsRooms.Where(b =>
                    (check.CheckInDate >= b.CheckInDate && check.CheckInDate < b.CheckOutDate) ||
                    (check.CheckOutDate > b.CheckInDate && check.CheckOutDate <= b.CheckOutDate)).ToListAsync();

            var activeRooms = await _context.Rooms.Where(r => r.IsActive == true).ToListAsync();
            var temps = await _context.TempRooms.ToListAsync();

            if (activeRooms == null || !activeRooms.Any())
            {
                return NotFound("No active rooms found.");
            }

            var filteredRooms = activeRooms.Where(room =>
                !existingBooking.Any(exist => exist.RoomId == room.RoomId) &&
                !temps.Any(temp => temp.RoomId == room.RoomId)).ToList();

            return filteredRooms;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Booking([FromBody] BookingRequestDto bookingRequest)
        {
            var tempCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.IdCard == bookingRequest.IdCard);
            int customerId;
            if (tempCustomer != null)
            {
                customerId = tempCustomer.CustomerId;
            }
            else
            {
                Customer newCustomer = new();
                newCustomer.IdCard = bookingRequest.IdCard;
                newCustomer.FullName = bookingRequest.FullName;
                newCustomer.Gender = bookingRequest.Gender;
                newCustomer.DOB = bookingRequest.DOB;
                newCustomer.Address = bookingRequest.Address;
                newCustomer.PhoneNumber = bookingRequest.Phone;
                newCustomer.Email = bookingRequest.Email;
                newCustomer.Country = bookingRequest.Country;

                await CreateCustomer(newCustomer);
                tempCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.IdCard == bookingRequest.IdCard);
                customerId = tempCustomer.CustomerId;
            }

            Invoice invoice = new Invoice();
            invoice.CreateDate = DateTime.Now;
            invoice.CustomerId = customerId;
            invoice.Moneys = 0;
            invoice.StaffId = bookingRequest.StaffId;

            var createInvoice = await CreateInvoice(invoice);
            if (createInvoice != null)
            {
                var tempInvoice = await _context.Invoices.FirstOrDefaultAsync(i => i.CreateDate == invoice.CreateDate);

                BookingsRoom bookingRoom = new BookingsRoom();
                bookingRoom.CreateDate = DateTime.Now;
                bookingRoom.InvoiceId = tempInvoice.InvoiceId;
                bookingRoom.TotalMoney = 0;
                bookingRoom.StaffId = bookingRequest.StaffId;

                var createBookingRoom = await CreateBookingsRoom(bookingRoom);
                if (createBookingRoom != null)
                {
                    var tempBookingRoom = await _context.BookingsRooms.FirstOrDefaultAsync(b => b.CreateDate == bookingRoom.CreateDate);
                    if (tempBookingRoom != null && _context.TempRooms != null)
                    {
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                double sum = 0;
                                foreach (var room in _context.TempRooms)
                                {
                                    var days = (room.CheckOutDate - room.CheckInDate).Days;
                                    DetailBookingsRoom detailBookingsRoom = new();
                                    detailBookingsRoom.BookingRoomId = tempBookingRoom.BookingRoomId;
                                    detailBookingsRoom.RoomId = room.RoomId;
                                    detailBookingsRoom.Name = room.Name;
                                    detailBookingsRoom.CheckInDate = room.CheckInDate;
                                    detailBookingsRoom.CheckOutDate = room.CheckOutDate;
                                    detailBookingsRoom.CreateDay = DateTime.Now;
                                    detailBookingsRoom.TotalMoney = room.Price * days;
                                    sum += detailBookingsRoom.TotalMoney;

                                    // Thực hiện công việc trong cùng một giao dịch
                                    await CreateDetailBookingsRoom(detailBookingsRoom);
                                }

                                // Commit giao dịch
                                await transaction.CommitAsync();

                                tempBookingRoom.TotalMoney = sum;
                                tempInvoice.Moneys = sum;
                                _context.Entry(tempBookingRoom).State = EntityState.Modified;
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
                }
            }

            return Ok();
        }

        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            if (_context.Invoices == null)
            {
                return Problem("Entity set 'MyHotelDbContext.Invoices'  is null.");
            }
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.InvoiceId }, invoice);
        }

        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'MyHotelDbContext.Customers'  is null.");
            }
            _context.Customers.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.IdCard))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }
        private bool CustomerExists(string IdCard)
        {
            return (_context.Customers?.Any(e => e.IdCard == IdCard)).GetValueOrDefault();
        }

        public async Task<ActionResult<BookingsRoom>> CreateBookingsRoom(BookingsRoom bookingsRoom)
        {
            if (_context.BookingsRooms == null)
            {
                return Problem("Entity set 'MyHotelDbContext.BookingsRooms'  is null.");
            }
            _context.BookingsRooms.Add(bookingsRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingsRoom", new { id = bookingsRoom.BookingRoomId }, bookingsRoom);
        }

        public async Task<ActionResult<DetailBookingsRoom>> CreateDetailBookingsRoom(DetailBookingsRoom detailBookingsRoom)
        {
            if (_context.DetailBookingsRooms == null)
            {
                return Problem("Entity set 'MyHotelDbContext.DetailBookingsRooms'  is null.");
            }
            _context.DetailBookingsRooms.Add(detailBookingsRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailBookingsRoom", new { id = detailBookingsRoom.DBR_Id }, detailBookingsRoom);
        }
    }
}
