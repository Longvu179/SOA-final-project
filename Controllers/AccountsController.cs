using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyHotel.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MyHotelDbContext _context;

        public AccountsController(MyHotelDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.email == model.email);

            if (account != null && account.password == model.password)
            {
                var staff = await _context.Staffs.FindAsync(account.StaffId);
                if (staff != null)
                {
                    return BadRequest("Cannot find this staff");
                }
                return Ok(staff);
            }
            else
            {
                return Unauthorized();
            }
        }

        /*private string GenerateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("my_hotel_secret_key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, account.username),
                    new Claim(ClaimTypes.Role, account.role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }*/
    }
}
