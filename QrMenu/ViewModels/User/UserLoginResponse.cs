using QrMenu.ViewModels.Auth;

namespace QrMenu.ViewModels.User
{
    public class UserLoginResponse : UserView
    {
        public GenerateTokenResponse AuthToken { get; set; }
        public bool Success { get; set; }
    }
}
