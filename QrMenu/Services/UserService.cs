using QrMenu.Data.Repositories;
using QrMenu.Models.User;
using QrMenu.Utils;
using QrMenu.Utils.Auth;
using QrMenu.Utils.Mapping;
using QrMenu.ViewModels.User;

namespace QrMenu.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task<List<UserView>> GetAllUsers()
        {
            var userList = await userRepository.GetAllUsers();

            var userListMapped = userList.Map<List<User>, List<UserView>>();

            return userListMapped;
        }

        public async Task<UserView> GetUserById(string id)
        {
            return (await userRepository.GetUserById(id)).Map<User, UserView>();
        }

        public async Task<UserView> GetUserByEmail(string email)
        {
            return (await userRepository.GetUserByEmail(email)).Map<User, UserView>();

        }

        public async Task<bool> AddUser(UserInsert insertModel)
        {
            var existUser = await userRepository.GetUserByUsername(insertModel.Username);

            if (existUser is not null) return false;

            var user = insertModel.Map<UserInsert, User>();

            user.Password = passwordHasher.HashPassword(user.Password);

            user.CreateDate = DateTime.Now.TrimMilliseconds();
            user.IsActive = true;
            user.IsMailConfirmed = true;

            var insertUser = await userRepository.AddUser(user);

            return insertUser == null;
        }

        public async Task<bool> UpdateUser(string id, User user)
        {
            return await userRepository.UpdateUser(id, user);
        }

        public async Task<bool> RemoveUser(string id)
        {
            return await userRepository.RemoveUser(id);
        }
    }
}

