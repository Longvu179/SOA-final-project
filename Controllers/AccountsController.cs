using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyHotel.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MyHotel.Models.ViewModel;
using MyHotel.Models.InputModel;
using MyHotel.Email_Sender;


namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MyHotelDbContext _context;
        private readonly IEmailSender _emailSender;

        public AccountsController(MyHotelDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.email == model.email);

            if (account != null && account.password == model.password)
            {
                var staff = await _context.Staffs.FindAsync(account.StaffId);
                if (staff == null)
                {
                    return BadRequest("Cannot find this staff");
                }
                var data = new AccountViewModel
                {
                    Id = staff.StaffId,
                    Name = staff.FullName,
                    position = staff.Position,
                };
                return Ok(data);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(AccountCreateModel model)
        {
            if (model.Name == null & model.Gender == null)
            {
                return BadRequest();
            }
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.email == model.Email);
            if(account != null)
            {
                return Conflict("Account already exist");
            }
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var password = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var newStaff = new Staff
            {
                FullName = model.Name,
                Email = model.Email,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                Position = model.Position
            };
            _context.Staffs.Add(newStaff);
            await _context.SaveChangesAsync();
            var newAccount = new Account
            {
                email = model.Email,
                password = password,
                StaffId = newStaff.StaffId,
            };

            var emailSubject = "Your Account Information";
            var emailBody = $"Hello {model.Name},\n\nYour account has been created successfully.\n\nYour password: {password}\n\nPlease keep it safe.";
            await _emailSender.SendEmailAsync(model.Email, emailSubject, emailBody);

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();
            return Ok("Account created successfully");
        }

        [HttpPost("change-password")]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            // Find the account by email
            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.email == model.Email);
            if (account == null)
            {
                return NotFound("Account not found");
            }

            // Verify the current password
            if (model.NewPassword != model.ConfirmPassword)
            {
                return BadRequest("Invalid current password");
            }

            // Update the password
            account.password = model.NewPassword;
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();

            return Ok("Password changed successfully");
        }
    }
}
