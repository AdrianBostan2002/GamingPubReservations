using BusinessLayer.Dtos;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamingPubReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingPubController : ControllerBase
    {
        private GamingPubService _gamingPubService;
        public GamingPubController(GamingPubService gamingPubService)
        {
            _gamingPubService = gamingPubService;
        }

        [HttpGet("all_gaming_pubs")]
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult<List<GamingPub>> GetAllGamingPubs()
        {
            return Ok(_gamingPubService.GetAll());
        }

        [HttpPost("add_gaming_pub")]
        [Authorize(Roles = "Admin")]
        public ActionResult PostNewPub([FromBody] AddGamingPubDto gamingPub)
        {
            if (_gamingPubService.AddGamingPub(gamingPub))
            {
                return Ok("Gaming pub added");
            }
            return BadRequest("Gaming pub already exists");
        }
    }
}