using System.ComponentModel.DataAnnotations;

namespace Wellmer.Models    //prisijungimo forma
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Vardas")]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [Display(Name = "Prisiminti mane?")]
        public bool RememberMe { get; set; }
    }
}
