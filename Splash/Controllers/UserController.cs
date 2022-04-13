using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Member.Data.Repository;
using Member.Data.Interface;
using Member.Data.Models;
using Splash.Services;
using Microsoft.Extensions.Configuration;

namespace POCProject.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private UserService usersService = new UserService();

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [Route("api/GetAllUsers")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await usersService.GetAllUsers();
            return users;
        }

        [HttpGet]
        [Route("api/GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var x = await usersService.GetUserById(id);
            return x;
        }
        [Route("api/CreateUser")]
        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(User item)
        {
            if (item == null)
                return BadRequest();

            var usersData = await usersService.AddUser(item);
            return usersData;
        }
        [Route("api/UpdateUser/{id}")]
        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = await usersService.GetUserById(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            var usersData = await usersService.UpdateUser(item);
            return usersData;
        }
        [HttpDelete]
        [Route("api/DeleteUser/{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var usersData = await usersService.DeleteUser(id);
            return usersData;
        }
        public string Index()
        {
            string defaultConnection = this._config.GetSection("ConnectionStrings")["DefaultConnection"];
            return defaultConnection;
        }
    }
}
