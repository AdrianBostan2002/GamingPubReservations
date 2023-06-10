using BusinessLayer.Dtos;
using BusinessLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public class ReservationService
    {
        private readonly UnitOfWork unitOfWork;

        public ReservationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool AddReservation(AddOrUpdateReservationDto addReservationDto)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetById(addReservationDto.GamingPubId);

            if (foundGamingPub == null)
            {
                return false;
            }

            var foundGamingPlatform = unitOfWork.GamingPlatforms.GetById(addReservationDto.GamingPlatformId);

            if (foundGamingPlatform == null)
            {
                return false;
            }

            Reservation reservation = addReservationDto.ToReservation();

            reservation.GamingPub = foundGamingPub;
            reservation.GamingPlatform = foundGamingPlatform;

            unitOfWork.Reservations.Insert(reservation);

            unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdateReservation(AddOrUpdateReservationDto updateReservationDto, int reservationId)
        {
            Reservation foundReservation = unitOfWork.Reservations.GetById(reservationId);

            if(foundReservation == null)
            {
                return false;
            }

            var foundGamingPub = unitOfWork.GamingPubs.GetById(updateReservationDto.GamingPubId);
            var foundGamingPlatform = unitOfWork.GamingPlatforms.GetById(updateReservationDto.GamingPlatformId);

            if (foundGamingPub == null || foundGamingPlatform == null)
            {
                return false;
            }

            Reservation updatedReservation = updateReservationDto.ToReservation();
            
            updatedReservation.Copy(foundReservation);
            
            foundReservation.GamingPub = foundGamingPub;
            foundReservation.GamingPlatform = foundGamingPlatform;

            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteReservation(int reservationId)
        {
            var foundReservation = unitOfWork.Reservations.GetById(reservationId);

            if (foundReservation == null)
            {
                return false;
            }

            unitOfWork.Reservations.Remove(foundReservation);

            unitOfWork.SaveChanges();

            return true;
        }

        public List<Reservation> GetAll()
        {
            return unitOfWork.Reservations.GetAll();
        }
    }
}