using System.ComponentModel.DataAnnotations;

namespace QrMenu.ViewModels.Auth
{
    public class ConfirmCodeRequest
	{
		[Required]
		public string UserId { get; set; }
        [Required]
        public string ConfirmCode { get; set; }

    }
}

