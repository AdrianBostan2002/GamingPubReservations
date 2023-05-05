using BusinessLayer.Dtos;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamingPubReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all_users")]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost("register_user")]
        public ActionResult PostNewUser([FromBody] AddUserDto user)
        {
            _userService.Register(user);
            return Ok();
        }

        [HttpDelete("delete_user")]
        public ActionResult DeleteUserById([FromBody] RemoveUserDto user)
        {
            if(_userService.RemoveUserById(user))
            {
                return Ok("User deleted");
            }
            return BadRequest("User is not in list of users");
        }

        [HttpPut("update_user_name")]
        public ActionResult PutUpdateUser([FromBody] UpdateUserDto user)
        {
            if(_userService.UpdateUser(user))
            {
                return Ok("User updated");
            }
            return BadRequest("User was not updated successfully");
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDto registerData)
        {
            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Register(LoginDto loginData)
        {
            return Ok();
        }
    }
}