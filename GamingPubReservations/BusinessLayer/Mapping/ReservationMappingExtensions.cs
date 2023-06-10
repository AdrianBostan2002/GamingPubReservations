using BusinessLayer.Dtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Mapping
{
    public static class ReservationMappingExtensions
    {
        public static Reservation ToReservation(this AddOrUpdateReservationDto reservationDto)
        {
            return new Reservation
            {
                StartDate = reservationDto.StartDate,
                EndDate = reservationDto.EndDate,
                GamingPlatformId = reservationDto.GamingPlatformId,
                GamingPubId = reservationDto.GamingPubId,
                UserId = reservationDto.UserId,
            };
        }

        public static void Copy(this Reservation source, Reservation destination)
        {
            destination.StartDate = source.StartDate;
            destination.EndDate = source.EndDate;
            destination.GamingPlatformId = source.GamingPlatformId;
            destination.GamingPlatform = source.GamingPlatform == null ? null : source.GamingPlatform;
            destination.GamingPub = source.GamingPub == null ? null : source.GamingPub;
            destination.GamingPubId = source.GamingPubId;
            destination.UserId = source.UserId;
        }
    }
}