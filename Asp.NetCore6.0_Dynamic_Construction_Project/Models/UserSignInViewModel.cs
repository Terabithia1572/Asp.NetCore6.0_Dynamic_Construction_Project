using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
        public string password { get; set; }
    }
}
