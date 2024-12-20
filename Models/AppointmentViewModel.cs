using System.ComponentModel.DataAnnotations;

namespace RumisBC.Models
{
    public class AppointmentViewModel
    {
        public DateTime BookingDate { get; set; }
        public string Expertise { get; set; }
        public string EmployerName { get; set; }
        public decimal Price { get; set; }
    }
}

