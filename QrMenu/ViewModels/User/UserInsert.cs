using System.ComponentModel.DataAnnotations;

namespace QrMenu.ViewModels.User
{
    public class UserInsert
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

