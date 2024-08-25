using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz..")]
        public string NameSurname { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz..")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor..")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen Mail Giriniz..")]
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Giriniz..")]
        public string UserName { get; set; }
        public string ImageUrl { get; set; }  // Kullanıcı tarafından yüklenen görsel

    }
}
