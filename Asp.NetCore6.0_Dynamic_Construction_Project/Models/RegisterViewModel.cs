using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string NameSurname { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public IFormFile ProfileImage { get; set; }
    }
}
