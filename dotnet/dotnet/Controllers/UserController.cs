using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Repositories;
using dotnet.Domain;
using Microsoft.AspNetCore.Mvc;
using dotnet.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public List<User> ListUsers()
        {
            return _userRepository.ListUsers();
        }

        [HttpPost]
        public ObjectResult CreateUser(User User)
        {
            _userRepository.CreateUser(User);
            return new ObjectResult(_userRepository.GetUserByEmail(User.Email));

        }
    }
}

