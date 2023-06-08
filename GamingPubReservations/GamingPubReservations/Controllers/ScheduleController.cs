using BusinessLayer.Dtos;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingPubReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private ScheduleService _scheduleService;
        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("add_schedule")]
        public IActionResult PostNewSchedule([FromBody] AddScheduleDto addScheduleDto)
        {
            if(_scheduleService.AddSchedule(addScheduleDto))
            {
                return Ok("Schedule added");
            }
            return BadRequest("Gaming Pub doesn't exist or it has already a schedule");
        }
    }
}
