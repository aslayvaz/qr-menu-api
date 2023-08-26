using QrMenu.Models;
using QrMenu.Models.Auth;

namespace QrMenu.Utils.Auth
{
    public interface IJwtTokenGenerator
    {
        GenerateTokenResponse GenerateToken(User user);
    }
}