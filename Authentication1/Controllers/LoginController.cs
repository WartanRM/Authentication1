using Microsoft.AspNetCore.Mvc;
using Authentication1.Data;
using Authentication1.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Login(string username, string password)
        {
            var hashedPassword = await HashPasswordAsync(password);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == hashedPassword);

            if (user == null)
            {
                return NotFound("Invalid credentials");
            }

            return Ok($"Welcome, {user.UserName}!");
        }
        private async Task<string> HashPasswordAsync(string password)
        {
            return await Task.Run(() =>
            {
                using var sha256 = System.Security.Cryptography.SHA256.Create();
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            });
        }
    }
}