using QrMenu.Data.Repositories;
using QrMenu.Models.ConfirmCode;
using QrMenu.Models.User;
using QrMenu.Services.Mail;
using QrMenu.Utils;
using QrMenu.Utils.Auth;
using QrMenu.Utils.Mail;
using QrMenu.Utils.Mapping;
using QrMenu.ViewModels.Auth;
using QrMenu.ViewModels.User;

namespace QrMenu.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IConfirmCodesRepository confirmCodesRepository;
        private readonly IMailService mailService;

        public AuthService(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher,
            IConfirmCodesRepository confirmCodesRepository,
            IMailService mailService)
        {
            this.userRepository = userRepository;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.passwordHasher = passwordHasher;
            this.confirmCodesRepository = confirmCodesRepository;
            this.mailService = mailService;
        }

        public async Task<UserLoginResponse> Login(string username, string password)
        {
            var user = await userRepository.GetUserByUsername(username);

            if (user is null) return null;

            bool isAuth = passwordHasher.VerifyPassword(user.Password, password);

            if (isAuth && user.IsMailConfirmed)
            {
                var authUser = user.Map<UserDatabaseModel, UserLoginResponse>();
                var token = jwtTokenGenerator.GenerateToken(user);
                authUser.AuthToken = token;
                authUser.Success = true;
                return authUser;
            }
            return null;
        }

        public async Task<UserRegisterResponse> Register(UserRegisterRequest userRegister)
        {

            var existUser = await userRepository.GetUserByUsername(userRegister.Username);

            if (existUser != null && existUser.IsActive) return null;

            var user = userRegister.Map<UserRegisterRequest, UserDatabaseModel>();

            user.Password = passwordHasher.HashPassword(user.Password);

            user.CreateDate = DateTime.Now.TrimMilliseconds();

            var insert = await userRepository.AddUser(user);
            var confirmCode = new ConfirmCode
            {
                UserId = insert.Id,
                Code = CreateConfirmCode(),
                Expires = DateTime.Now.AddMinutes(30)
            };
            await confirmCodesRepository.InsertConfirmCode(confirmCode);

            await SendConfirmMail(confirmCode.Code, userRegister.Username, userRegister.Email);

            var response = insert.Map<UserDatabaseModel, UserRegisterResponse>();

            return response;
        }

        public async Task<bool> ConfirmUserEmail(ConfirmCodeRequest confirmCode)
        {
            var existUser = await userRepository.GetUserById(confirmCode.UserId);

            if (existUser == null || existUser.IsMailConfirmed) return false;

            var confirmExists = await confirmCodesRepository.GetConfirmCode(confirmCode.UserId);

            if (confirmExists != null &&
                confirmExists.Expires < DateTime.Now &&
                confirmExists.Code == confirmCode.ConfirmCode)
            {
                existUser.IsMailConfirmed = true;
                existUser.IsActive = true;
                existUser.LastEditDate = DateTime.Now;
                return await userRepository.UpdateUser(confirmCode.UserId, existUser);
            }

            return false;
        }

        private static string CreateConfirmCode()
        {
            const int length = 6;
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private async Task SendConfirmMail(string code, string username, string email)
        {
            var mailContent = new MailConfirmCodeDraft(code, username);

            string subject = mailContent.Subject;
            string body = mailContent.Body;
            await mailService.SendEmailAsync(email, subject, body);
        }
    }
}

