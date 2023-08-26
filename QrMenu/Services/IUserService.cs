using System;
using QrMenu.Models;
using QrMenu.ViewModels.User;

namespace QrMenu.Services
{
    public interface IUserService
	{
        Task<List<UserView>> GetAllUsers();
        Task<UserView> GetUserById(string id);
        Task<UserView> GetUserByEmail(string email);
        Task<bool> AddUser(UserInsert insertModel);
        Task<bool> UpdateUser(string id, User User);
        Task<bool> RemoveUser(string id);
    }
}

