using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using QrMenu.Models;
using QrMenu.Models.Auth;

namespace QrMenu.Utils.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public GenerateTokenResponse GenerateToken(User user)
        {
            // Get the JWT token configuration from the appsettings.json.
            var jwtConfig = new JwtConfig();
            configuration.GetSection("Jwt").Bind(jwtConfig);

            // Create the JWT token.
            var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
                };

            DateTime dateNow = DateTime.Now;

            var token = new JwtSecurityToken(
                issuer: jwtConfig.Issuer,
                audience: jwtConfig.Audience,
                claims: claims,
                notBefore:dateNow,
                expires: dateNow.AddDays(jwtConfig.ExpiresInDays),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret)),
                    SecurityAlgorithms.HmacSha256)
            );

            return new GenerateTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                TokenExpireDate = dateNow.AddDays(jwtConfig.ExpiresInDays)
            };
            
        }
    }
}

