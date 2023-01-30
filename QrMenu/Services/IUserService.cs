using System;
using QrMenu.Models;
using QrMenu.ViewModels;

namespace QrMenu.Services
{
	public interface IUserService
	{
        Task<List<UserViewModel>> GetAllUsers();
        Task<UserViewModel> GetUserById(string id);
        Task<UserViewModel> GetUserByEmail(string email);
        Task<bool> AddUser(UserInsertModel insertModel);
        Task<bool> UpdateUser(string id, User User);
        Task<bool> RemoveUser(string id);
    }
}

