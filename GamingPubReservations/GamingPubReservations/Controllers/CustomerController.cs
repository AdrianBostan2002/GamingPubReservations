using BusinessLayer.Dtos;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamingPubReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _customerService;

        public UserController(UserService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("all_customers")]
        public ActionResult<List<User>> GetAllUsers()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }

        [HttpPost("add_customer")]
        public ActionResult PostNewUser([FromBody] AddUserDto customer)
        {
            if(_customerService.AddUser(customer))
            {
                return Ok("User added");
            }
            return BadRequest("User is already added");
        }

        [HttpDelete("delete_customer")]
        public ActionResult DeleteUserById([FromBody] RemoveUserDto customer)
        {
            if(_customerService.RemoveUserById(customer))
            {
                return Ok("User deleted");
            }
            return BadRequest("User is not in list of users");
        }

        [HttpPut("update_customer_name")]
        public ActionResult PutUpdateUser([FromBody] UpdateUserDto customer)
        {
            if(_customerService.UpdateUser(customer))
            {
                return Ok("User updated");
            }
            return BadRequest("User was not updated successfully");
        }
    }
}