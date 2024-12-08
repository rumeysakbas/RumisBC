using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RumisBC.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [Display(Name = "E-posta Adresi")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
    }
}

