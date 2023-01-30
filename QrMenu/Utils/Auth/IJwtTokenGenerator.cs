using QrMenu.Models;

namespace QrMenu.Utils.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}