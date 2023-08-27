using QrMenu.Data.Repositories;
using QrMenu.Models.User;
using QrMenu.Utils.Auth;
using QrMenu.Utils.Mapping;
using QrMenu.ViewModels.User;

namespace QrMenu.Services
{
    public class AuthenticatorService : IAuthenticatorService
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IPasswordHasher passwordHasher;

        public AuthenticatorService(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.passwordHasher = passwordHasher;
        }

        public async Task<UserLoginResponse> Login(string username, string password)
        {
            var user = await userRepository.GetUserByUsername(username);

            if (user is null) return null;

            bool isAuth = passwordHasher.VerifyPassword(user.Password, password);

            if (isAuth)
            {
                var authUser = user.Map<User, UserLoginResponse>();
                var token = jwtTokenGenerator.GenerateToken(user);
                authUser.AuthToken = token;
                return authUser;
            }
            return null;
        }
    }
}

