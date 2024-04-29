using Google.Protobuf.WellKnownTypes;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using System.Collections;
using Infrastructure.Models;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //instanciamos la interfaz, pero no la inicializamos
        private readonly IUserRepository _userRepository;
        //private readonly UserRepositoryMariaDB _userRepository;
        public UserController( 
            IUserRepository userRepository
            //UserRepositoryMariaDB userRepositoryMariaDB
         ) {
            //_userRepository = new UserRepository();
            _userRepository = userRepository;

        }

        [HttpGet]
        public IActionResult GetUsers() {
            //UserRepository userRepository = new UserRepository();
            //UserRepositoryMariaDB userRepository = new UserRepositoryMariaDB();
            var personas = _userRepository.GetAllUsers();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsersById(int id)
        {
            //UserRepository userRepository = new UserRepository();
            //UserRepositoryMariaDB userRepository = new UserRepositoryMariaDB();
            var personas = _userRepository.GetAllUsers();
            return Ok(personas);
        }

        [HttpPost]
        public IActionResult CreateUsers([FromBody] Infrastructure.Models.Users user) { 
            var createdUser = _userRepository.CreateUser(user);
            if (createdUser != null)
            {
                return Ok(createdUser);
            }
            else
            {
                // Handle error scenario (e.g., user creation failed)
                return BadRequest("User creation failed.");
            }
        }
        //public class Users
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Email { get; set; }
        //    public string Password { get; set; }

        //}
    }
}
