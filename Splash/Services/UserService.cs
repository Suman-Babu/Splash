using Member.Data.Interface;
using Member.Data.Models;
using Member.Data.Repository;

namespace Splash.Services
{
    public class UserService
    {
        private IUser users = new UserRepository();
        public async Task<List<User>> GetAllUsers()
        {
            return await users.GetAllUsers();
        }
        public async Task<User> GetUserById(int id)
        {
            return await users.GetUserById(id);
        }
        public async Task<List<User>> AddUser(User item)
        {
            return await users.AddUser(item);
        }
        public async Task<List<User>> UpdateUser(User item)
        {
            return await users.UpdateUser(item);
        }
        public async Task<List<User>> DeleteUser(int Id)
        {
            return await users.DeleteUser(Id);
        }
    }
}
