using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class ReservationsRepository
    {
        public List<Reservation> GetAll()
        {
            throw new NotImplementedException();
            //return new List<Reservation>(from pub in AppDbContext.GamingPubs
            //                                         where pub != null
            //                                         from reservation in pub.Reservations
            //                                         select reservation);
        }

        public void AddReservation(Reservation reservation, GamingPub gamingPub)
        {
            throw new NotImplementedException();
            //gamingPub.Reservations.Add(reservation);
        }

        public void RemoveReservation(Reservation reservation, GamingPub gamingPub)
        {
            throw new NotImplementedException();
            //gamingPub.Reservations.Remove(reservation);
        }
    }
}