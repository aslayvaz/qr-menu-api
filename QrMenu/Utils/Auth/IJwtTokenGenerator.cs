using QrMenu.Models.Auth;
using QrMenu.Models.User;

namespace QrMenu.Utils.Auth
{
    public interface IJwtTokenGenerator
    {
        GenerateTokenResponse GenerateToken(User user);
    }
}