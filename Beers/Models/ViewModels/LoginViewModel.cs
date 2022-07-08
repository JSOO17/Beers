using System.ComponentModel.DataAnnotations;

namespace Beers.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
