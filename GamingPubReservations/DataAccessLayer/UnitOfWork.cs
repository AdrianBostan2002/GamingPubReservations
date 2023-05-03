using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class UnitOfWork
    {
        public UsersRepository UsersRepository { get; }
        public GamingPubsRepository GamingPubsRepositoryGamingPubsRepository { get; }
        public ReservationsRepository ReservationsRepositoryReservationsRepository { get; }

        private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext,
            UsersRepository customersRepository,
            GamingPubsRepository gamingPubsRepositoryGamingPubsRepository,
            ReservationsRepository reservationsRepositoryReservationsRepository
        )
        {
            _dbContext = dbContext;
            UsersRepository = customersRepository;
            GamingPubsRepositoryGamingPubsRepository = gamingPubsRepositoryGamingPubsRepository;
            ReservationsRepositoryReservationsRepository = reservationsRepositoryReservationsRepository;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}