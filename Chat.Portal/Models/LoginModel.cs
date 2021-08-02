using System.ComponentModel.DataAnnotations;

namespace Chat.Portal.Models
{
    public class LoginModel
    {
        [Required, MinLength(4), MaxLength(16)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(16)]
        public string Password { get; set; }
    }
}