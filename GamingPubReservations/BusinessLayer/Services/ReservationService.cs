using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class ReservationService
    {
        private ReservationsRepository reservationsRepository;
        public ReservationService(ReservationsRepository reservationsRepository) 
        {
            this.reservationsRepository = reservationsRepository;
        }
        public List<Reservation> GetAll()
        {
            return reservationsRepository.GetAll();
        }
    }
}
