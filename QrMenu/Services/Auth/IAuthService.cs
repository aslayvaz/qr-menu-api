using QrMenu.ViewModels.Auth;
using QrMenu.ViewModels.User;

namespace QrMenu.Services.Auth
{
    public interface IAuthService
    {
        Task<UserLoginResponse> Login(string user, string password);
        Task<UserRegisterResponse> Register(UserRegisterRequest userRegister);
        Task<bool> ConfirmUserEmail(ConfirmCodeRequest confirmCode);
    }
}

