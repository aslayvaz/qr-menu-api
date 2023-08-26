using QrMenu.ViewModels.User;

namespace QrMenu.Services
{
    public interface IAuthenticatorService
	{
		Task<UserLoginResponse> Login(string user, string password);
	}
}

