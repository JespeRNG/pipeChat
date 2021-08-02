using System.ComponentModel.DataAnnotations;

namespace Chat.Portal.Models
{
    public class SignUpModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4), MaxLength(16)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(16)]
        public string Password { get; set; }
        [Required, MinLength(6), MaxLength(16)]
        public string RePassword { get; set; }
        [MinLength(6), MaxLength(16)]
        public string FirstName { get; set; }
        [MinLength(6), MaxLength(16)]
        public string LastName { get; set; }

    }
}