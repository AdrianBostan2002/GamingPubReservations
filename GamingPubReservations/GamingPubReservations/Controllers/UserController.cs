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
        public IActionResult Register([FromBody] RegisterDto registerData)
        {
            if (_userService.Register(registerData))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Email already in use");
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] LoginDto loginData)
        {
            var jwtToken = _userService.ValidateLogin(loginData);
            if(jwtToken == null)
            {
                return BadRequest("Wrong email or password");
            }
            return Ok(new { token = jwtToken });
        }
    }
}