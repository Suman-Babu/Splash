using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Data.Models;

namespace Member.Data.Interface
{
    public interface IUser
    {
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        Task<List<User>> AddUser(User item);
        Task<List<User>> DeleteUser(int Id);
        Task<List<User>> UpdateUser(User item);
    }
}
