using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyHotel;
using MyHotel.Models;
using NuGet.Protocol.Plugins;

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly MyHotelDbContext _context;

        public StaffsController(MyHotelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllStaffs()
        {
          if (_context.Staffs == null)
          {
              return NotFound();
          }
            return await _context.Staffs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
          if (_context.Staffs == null)
          {
              return NotFound();
          }
            var staff = await _context.Staffs.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest("Staff ID in the URL does not match the staff ID in the request body.");
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
                {
                    return NotFound("Staff not found.");
                }
                else
                {
                    throw; // Handle the exception as needed, such as logging or returning an error response.
                }
            }

            return NoContent();
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            if (_context.Staffs == null)
            {
                return NotFound();
            }
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.StaffId == id);
            if (account == null)
            {
                return NotFound();
            }
            _context.Accounts.Remove(account);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}
