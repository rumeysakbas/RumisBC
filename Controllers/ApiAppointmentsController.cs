using Microsoft.AspNetCore.Mvc;
using RumisBC.Models;

namespace RumisBC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAppointmentsController : ControllerBase
    {
        private readonly Context _context;
        private Context context = new Context();

        public ApiAppointmentsController()
        {
            _context = context;
        }

        // GET: api/ApiAppointments/{userId}
        [HttpGet("{userId}")]
        public IActionResult GetAppointmentsByUserId(string userId)
        {
            var appointments = _context.Bookings
                .Where(b => b.CustomerName == userId)
                .Select(b => new
                {
                    b.BookingDate,
                    b.Employer.Expertise,
                    EmployerName = b.Employer.FirstName + " " + b.Employer.LastName,
                    b.Employer.Price
                })
                .ToList();

            if (appointments == null || !appointments.Any())
            {
                return NotFound(new { Message = "Kullanıcıya ait randevular bulunamadı." });
            }

            return Ok(appointments);
        }
    }
}
