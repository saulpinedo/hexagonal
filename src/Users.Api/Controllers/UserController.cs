using Google.Protobuf.WellKnownTypes;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using System.Collections;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
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


        //public IActionResult GetUserss()
        //{
        //    IActionResult actionResult = null;
        //}
    }
}
