using Insurance_server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Insurance_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly InsuranceDbContext _context;

        public LoginController(InsuranceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AuthenticateUser([FromBody] LoginRequest request)
        {
            var user = _context.UserLoginDetails.SingleOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (user.Password != request.Password)
            {
                return Unauthorized("Invalid password");
            }

            return Ok(new { user.UserId, user.Email });
        }
    }

  

}
