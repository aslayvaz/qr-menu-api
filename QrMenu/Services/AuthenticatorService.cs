using QrMenu.Data.Repositories;
using QrMenu.Models;
using QrMenu.Utils.Auth;
using QrMenu.Utils.Mapping;
using QrMenu.ViewModels;

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

        public async Task<UserAuthViewModel> Login(string username, string password)
        {
            var user = await userRepository.GetUserByUsername(username);

            if (user is null) return null;

            bool isAuth = passwordHasher.VerifyPassword(user.Password, password);

            if (isAuth)
            {
                var authUser = user.Map<User, UserAuthViewModel>();
                authUser.Token = jwtTokenGenerator.GenerateToken(user);
                return authUser;
            }
            return null;
        }
    }
}

