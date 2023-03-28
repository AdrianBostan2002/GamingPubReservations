using BusinessLayer.Dtos;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamingPubReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("all_customers")]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }

        [HttpPost("add_customer")]
        public ActionResult PostNewCustomer([FromBody] AddCustomerDto customer)
        {
            if(_customerService.AddCustomer(customer))
            {
                return Ok("Customer added");
            }
            return BadRequest("Customer is already added");
        }

        [HttpDelete("delete_customer")]
        public ActionResult DeleteCustomerById([FromBody] RemoveCustomerDto customer)
        {
            if(_customerService.RemoveCustomerById(customer))
            {
                return Ok("Customer deleted");
            }
            return BadRequest("Customer is not in list of users");
        }

        [HttpPut("update_customer_name")]
        public ActionResult PutUpdateCustomer([FromBody] UpdateCustomerDto customer)
        {
            if(_customerService.UpdateCustomer(customer))
            {
                return Ok("Customer updated");
            }
            return BadRequest("Customer was not updated successfully");
        }
    }
}