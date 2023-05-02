using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamingPubReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("all_reservations")]
        public ActionResult<List<Reservation>> GetAllReservations()
        {
            var reservations = _reservationService.GetAll();
            return Ok(reservations);
        }

    }
}
