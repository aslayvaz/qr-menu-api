using System.ComponentModel.DataAnnotations;

namespace QrMenu.ViewModels.User
{
    public class UserRegisterRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}

