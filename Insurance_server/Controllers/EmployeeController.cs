using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Insurance_server.Models;

namespace Insurance_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly InsuranceDbContext _context;

        public EmployeeController(InsuranceDbContext context)
        {
            _context = context;
        }

        [HttpGet("{UserId}")]
        public IActionResult GetEmployee(int UserId)
        {
            var employee = _context.EmployeeDetails.Find(UserId);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}
