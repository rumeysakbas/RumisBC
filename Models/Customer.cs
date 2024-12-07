using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RumisBC.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        //dkjsnc
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        [Display(Name = "First Name - Ad")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [Display(Name = "E-posta Adresi")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "En fazla 20 karakter kullanabilirsiniz.")]
        [MinLength(5, ErrorMessage = "En az 5 karakter kullanmalısınız.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [MaxLength(20, ErrorMessage = "En fazla 20 karakter kullanabilirsiniz.")]
        [MinLength(5, ErrorMessage = "En az 5 karakter kullanmalısınız.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen yaşınızı giriniz.")]
        [Display(Name = "Yaş")]
        [Range(18, 120, ErrorMessage = "Yaşınız 18 den büyük olmalıdır.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numaranızı giriniz.")]
        [Display(Name = "Telefon Numarası")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen TC numaranızı giriniz.")]
        [Display(Name = "TC Numarası")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Geçerli bir TC numarası giriniz.")]
        [StringLength(11)]
        public string TC { get; set; }



    }
}
