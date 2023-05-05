using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class UnitOfWork
    {
        public UsersRepository UsersRepository { get; }
        public GamingPubsRepository GamingPubsRepository { get; }
        public ReservationsRepository ReservationsRepository { get; }
        public AddressRepository AddressRepository { get; }

        private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext,
            UsersRepository customersRepository,
            GamingPubsRepository gamingPubsRepository,
            ReservationsRepository reservationsRepository,
            AddressRepository addressRepository
        )
        {
            _dbContext = dbContext;
            UsersRepository = customersRepository;
            GamingPubsRepository = gamingPubsRepository;
            ReservationsRepository = reservationsRepository;
            AddressRepository = addressRepository;
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