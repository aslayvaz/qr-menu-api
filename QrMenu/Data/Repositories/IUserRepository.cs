using System;
using QrMenu.Models;

namespace QrMenu.Data.Repositories
{
	public interface IUserRepository
	{
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> GetUserByEmail(string email);
        Task<bool> AddUser(User User);
        Task<bool> UpdateUser(string id, User User);
        Task<bool> RemoveUser(string id);
    }
}

