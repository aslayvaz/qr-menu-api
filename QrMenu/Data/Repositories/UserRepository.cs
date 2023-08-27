using MongoDB.Driver;
using QrMenu.Models.User;

namespace QrMenu.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> users;

        public UserRepository(IMongoDatabase database)
        {
            this.users = database.GetCollection<User>("users"); ;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var userlist = await users.Find(r => true).ToListAsync();

            if (userlist is null) return null;

            return userlist;
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await users.Find(u => u.Id == id).FirstOrDefaultAsync();

            if (user is null) return null;

            return user;

        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await users.Find(u => u.Email == email).FirstOrDefaultAsync();

            if (user is null) return null;

            return user;
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                await users.InsertOneAsync(user);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RemoveUser(string id)
        {
            var deleteUser = await users.DeleteOneAsync(u => u.Id == id);
            return deleteUser.IsAcknowledged;
        }

        public async Task<bool> UpdateUser(string id, User user)
        {
            var updateUser = await users.ReplaceOneAsync(u => u.Id == id, user);
            return updateUser.IsAcknowledged;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await users.Find(u => u.Username == username).FirstOrDefaultAsync();

            if (user is null) return null;

            return user;
        }
    }
}

