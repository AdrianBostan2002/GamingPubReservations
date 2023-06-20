﻿using BusinessLayer.Dtos;
using BusinessLayer.Infos;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamingPubReservations.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("add")]
        public IActionResult PostNewReservation(AddOrUpdateReservationDto addReservationDto)
        {
            if (_reservationService.AddReservation(addReservationDto))
            {
                return Ok("Reservation added");
            }
            return BadRequest();
        }

        [HttpPut("update/{reservationId}")]
        public IActionResult UpdateReservation([FromBody] AddOrUpdateReservationDto updateReservationDto, [FromRoute] int reservationId)
        {
            if (_reservationService.UpdateReservation(updateReservationDto, reservationId))
            {
                return Ok("Reservation updated");
            }
            return BadRequest($"Reservation wasn't updated because reservation with id {reservationId} doesn't exist");
        }

        [HttpDelete("delete/{reservationId}")]
        public IActionResult DeleteReservation([FromRoute] int reservationId)
        {
            if (_reservationService.DeleteReservation(reservationId))
            {
                return Ok("Reservation deleted");
            }
            return BadRequest($"Reservation wasn't deleted because reservation with id {reservationId} doesn't exist");
        }

        [HttpGet("availables_by_date/{date}/{gamingPubId}")]
        public ActionResult<List<AvailableReservation>> GetAvailableReservationsByDate([FromRoute] DateTime date, [FromRoute] int gamingPubId)
        {
            return _reservationService.GetAvailablesByDate(date, gamingPubId);
        }

        [HttpGet("availables_by_date_and_platform/{date}/{gamingPlatformId}/{gamingPubId}")]
        public ActionResult<List<AvailableReservation>> GetAvailableReservationsByDate([FromRoute] DateTime date, [FromRoute] int gamingPlatformId, [FromRoute] int gamingPubId)
        {
            return _reservationService.GetAvailablesByDateAndPlatform(date, gamingPlatformId, gamingPubId);
        }

        [HttpGet("all_reservations")]
        public ActionResult<List<Reservation>> GetAllReservations()
        {
            var reservations = _reservationService.GetAll();
            return Ok(reservations);
        }

        [HttpGet("by_date/{date}/{gamingPubId}")]
        public ActionResult<List<ReservationInfo>> GetReservationsInfoByDate([FromRoute] DateTime date, [FromRoute] int gamingPubId)
        {
            return _reservationService.GetByDate(date, gamingPubId);
        }

        [HttpGet("by_range_of_days/{startDate}/{endDate}/{gamingPubId}")]
        public ActionResult<List<ReservationInfo>> GetReservationsInfoByDate([FromRoute] DateTime startDate, [FromRoute] DateTime endDate, [FromRoute] int gamingPubId)
        {
            return _reservationService.GetByRange(startDate, endDate, gamingPubId);
        }
    }
}