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
        public async Task<ActionResult<Staff>> GetStaff(string id)
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

        [HttpPost]
        public async Task<ActionResult<Staff>> AddStaff(Staff staff)
        {
            if (_context.Staffs == null)
            {
                return Problem("Entity set 'MyHotelDbContext.Staffs' is null.");
            }

            var account = new Account
            {
                username = staff.StaffId,
                password = staff.StaffId,
                email = staff.Email,
                role = staff.Position
            };

            _context.Accounts.Add(account);
            _context.Staffs.Add(staff);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StaffExists(staff.StaffId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(string id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(string id)
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

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExists(string id)
        {
            return (_context.Staffs?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
    }
}
