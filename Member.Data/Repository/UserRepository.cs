using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Data.Interface;
using Member.Data.Models;

namespace Member.Data.Repository
{
    public class UserRepository : IUser
    {
        List<User> lstUsers = new List<User>
        {
            new User{UserId=1, FirstName="Kirtesh", LastName="Shah", Address="Vadodara" },
            new User{UserId=2, FirstName="Nitya", LastName="Shah", Address="NewYork" },
            new User{UserId=3, FirstName="Dilip", LastName="Shah", Address="London" },
            new User{UserId=4, FirstName="Atul", LastName="Shah", Address="Australia" },
            new User{UserId=5, FirstName="Swati", LastName="Shah", Address="Boston" },
            new User{UserId=6, FirstName="Rashmi", LastName="Shah", Address="Seattle" },
        };

        public async Task<List<User>> GetAllUsers()
        {
            return await Task.FromResult(lstUsers.ToList());
        }

        public async Task<User> GetUserById(int id)
        {
            return await Task.FromResult(lstUsers.FirstOrDefault(x => x.UserId == id));
        }

        public async Task<List<User>> AddUser(User item)
        {
            lstUsers.Add(item);
            return await Task.FromResult(lstUsers);
        }
        public async Task<List<User>> DeleteUser(int Id)
        {
            var selectedUser = lstUsers.SingleOrDefault(x=>x.UserId == Id);
            if (selectedUser != null)
            {
                lstUsers.Remove(selectedUser);
            }
            return await Task.FromResult(lstUsers);
        }

        public async Task<List<User>> UpdateUser(User item)
        {
            var selectedUser = lstUsers.SingleOrDefault(x => x.UserId == item.UserId);
            selectedUser.FirstName = item.FirstName;
            selectedUser.LastName = item.LastName;
            selectedUser.Address = item.Address;

            return await Task.FromResult(lstUsers);
        }
    }
}
