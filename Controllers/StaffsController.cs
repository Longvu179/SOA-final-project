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
