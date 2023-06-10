using BusinessLayer.Dtos;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamingPubReservations.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ScheduleController : ControllerBase
    {
        private ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("schedule")]
        public IActionResult PostNewSchedule([FromBody] AddScheduleDto addScheduleDto)
        {
            if (_scheduleService.AddSchedule(addScheduleDto))
            {
                return Ok("Schedule added");
            }
            return BadRequest("Gaming Pub doesn't exist or it has already a schedule");
        }

        [HttpPost("schedule/{sourceGamingPubId}/{destinationGamingPubId}")]
        public IActionResult AddSameScheduleForDifferentGamingPub(int sourceGamingPubId, int destinationGamingPubId)
        {
            if (_scheduleService.AddSameScheduleForDifferentGamingPub(sourceGamingPubId, destinationGamingPubId))
            {
                return Ok("Schedule added");
            }
            return BadRequest($"There are no gaming pub with id {sourceGamingPubId} or {destinationGamingPubId}, " +
                $"or Source Gaming Pub doesn't have a schedule");
        }

        [HttpPut("update_day/{gamingPubId}")]
        public IActionResult UpdateDay([FromBody] AddOrUpdateDayScheduleDto updateDayScheduleDto, [FromRoute] int gamingPubId)
        {
            if (_scheduleService.UpdateDaySchedule(updateDayScheduleDto, gamingPubId))
            {
                return Ok("Day updated");
            }
            return BadRequest($"GamingPub with id {gamingPubId} doesn't exist");
        }

        [HttpDelete("schedule/{gamingPubId}")]
        public IActionResult DeleteSchedule([FromRoute] int gamingPubId)
        {
            if (_scheduleService.DeleteSchedule(gamingPubId))
            {
                return Ok("Schedule deleted");
            }
            else
            {
                return BadRequest("GamingPub doesn't have any schedule");
            }
        }
    }
}