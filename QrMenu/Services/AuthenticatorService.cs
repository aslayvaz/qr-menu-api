﻿using QrMenu.Data.Repositories;
using QrMenu.Models.ConfirmCode;
using QrMenu.Models.User;
using QrMenu.Utils;
using QrMenu.Utils.Auth;
using QrMenu.Utils.Mapping;
using QrMenu.ViewModels.Auth;
using QrMenu.ViewModels.User;

namespace QrMenu.Services
{
    public class AuthenticatorService : IAuthenticatorService
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IConfirmCodesRepository confirmCodesRepository;

        public AuthenticatorService(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher,
            IConfirmCodesRepository confirmCodesRepository)
        {
            this.userRepository = userRepository;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.passwordHasher = passwordHasher;
            this.confirmCodesRepository = confirmCodesRepository;
        }

        public async Task<UserLoginResponse> Login(string username, string password)
        {
            var user = await userRepository.GetUserByUsername(username);

            if (user is null) return null;

            bool isAuth = passwordHasher.VerifyPassword(user.Password, password);

            if (isAuth && user.IsMailConfirmed)
            {
                var authUser = user.Map<User, UserLoginResponse>();
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

            var user = userRegister.Map<UserRegisterRequest, User>();

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

            var response = insert.Map<User, UserRegisterResponse>();

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
    }
}

