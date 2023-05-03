using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class ReservationsRepository: RepositoryBase<Reservation>
    {
        public ReservationsRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}