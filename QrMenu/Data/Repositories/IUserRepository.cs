using QrMenu.Models.User;

namespace QrMenu.Data.Repositories
{
    public interface IUserRepository
	{
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User User);
        Task<bool> UpdateUser(string id, User User);
        Task<bool> RemoveUser(string id);
        Task<User> GetUserByUsername(string username);
    }
}

