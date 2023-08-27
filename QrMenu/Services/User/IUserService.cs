using QrMenu.Models.User;
using QrMenu.ViewModels.User;

namespace QrMenu.Services.User
{
    public interface IUserService
    {
        Task<List<UserView>> GetAllUsers();
        Task<UserView> GetUserById(string id);
        Task<UserView> GetUserByEmail(string email);
        Task<bool> AddUser(UserInsert insertModel);
        Task<bool> UpdateUser(string id, UserDatabaseModel User);
        Task<bool> RemoveUser(string id);
    }
}

