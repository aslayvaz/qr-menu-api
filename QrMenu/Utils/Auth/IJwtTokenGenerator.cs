using QrMenu.Models.User;
using QrMenu.ViewModels.Auth;

namespace QrMenu.Utils.Auth
{
    public interface IJwtTokenGenerator
    {
        GenerateTokenResponse GenerateToken(UserDatabaseModel user);
    }
}