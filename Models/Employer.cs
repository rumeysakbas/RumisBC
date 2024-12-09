using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RumisBC.Models
{
    [Table("Employer")]
    public class Employer
    {
        [Key]
        public int EmployerID { get; set; }

        [Required(ErrorMessage = "Lütfen calisan adıni giriniz.")]
        [Display(Name = "First Name - Ad")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Lütfen calisan soyadini giriniz.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Uzmanlık Alanı")]
        public string Expertise { get; set; }

        [Required]
        [Display(Name = "Çalışacağı Tarih")]
        [DataType(DataType.Date)]
        public DateTime WorkDate { get; set; }

        [Required]
        [Display(Name = "Başlangıç Saati")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; } 

        [Required]
        [Display(Name = "Bitiş Saati")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; } 

        public ICollection<Booking>? Booking { get; set; }
    }
}

