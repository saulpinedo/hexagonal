using Google.Protobuf.WellKnownTypes;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers() {
            
        UserRepository userRepository = new UserRepository();
            var personas = userRepository.GetAllUsers();
            return Ok(personas);


        }


        //public IActionResult GetUserss()
        //{
        //    IActionResult actionResult = null;
        //}
    }
}
