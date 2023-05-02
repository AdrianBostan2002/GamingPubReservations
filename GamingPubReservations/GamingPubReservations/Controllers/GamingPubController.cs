using BusinessLayer.Dtos;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamingPubReservations.Controllers
{
    public class GamingPubController : ControllerBase
    {
        private GamingPubService _gamingPubService;
        public GamingPubController(GamingPubService gamingPubService)
        {
            _gamingPubService = gamingPubService; 
        }
        [HttpGet("all_gaming_pubs")]
        public ActionResult<List<GamingPub>> GetAllGamingPubs()
        {
            return Ok(_gamingPubService.GetAll());
        }
        
        [HttpPost("add_gaming_pub")]
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
