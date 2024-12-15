using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RumisBC.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        [Display(Name = "Randevu Tarihi")]
        public DateTime BookingDate { get; set; } 

        [Required]
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; } 

        [Required]
        [Display(Name = "Çalışan ID")]
        public int EmployerID { get; set; } 

        [ForeignKey("EmployerID")]
        public Employer Employer { get; set; } 

    }
}

