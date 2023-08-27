using QrMenu.Models.User;

namespace QrMenu.Data.Repositories
{
    public interface IUserRepository
	{
        Task<List<UserDatabaseModel>> GetAllUsers();
        Task<UserDatabaseModel> GetUserById(string id);
        Task<UserDatabaseModel> GetUserByEmail(string email);
        Task<UserDatabaseModel> AddUser(UserDatabaseModel User);
        Task<bool> UpdateUser(string id, UserDatabaseModel User);
        Task<bool> RemoveUser(string id);
        Task<UserDatabaseModel> GetUserByUsername(string username);
    }
}

