using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class ReservationsRepository
    {
        public List<Reservation> GetAll()
        {
           return new List<Reservation>(from pub in AppDbContext.GamingPubs
                                                     where pub != null
                                                     from reservation in pub.Reservations
                                                     select reservation);
        }

        public void AddReservation(Reservation reservation, GamingPub gamingPub)
        {
            gamingPub.Reservations.Add(reservation);
        }

        public void RemoveReservation(Reservation reservation, GamingPub gamingPub)
        {
            gamingPub.Reservations.Remove(reservation);
        }
    }
}