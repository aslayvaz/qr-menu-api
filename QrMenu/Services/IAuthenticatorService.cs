using QrMenu.ViewModels;

namespace QrMenu.Services
{
    public interface IAuthenticatorService
	{
		Task<UserAuthViewModel> Login(string user, string password);
	}
}

