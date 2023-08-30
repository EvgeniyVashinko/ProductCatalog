using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.WebApp.ViewModels.Login
{
    public class RegistrationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password1 { get; set; }

        [Required]
        [Compare("Password1", ErrorMessage = "Пароль 1 и Пароль 2 должны совпадать")]
        public string Password2 { get; set; }
    }
}
