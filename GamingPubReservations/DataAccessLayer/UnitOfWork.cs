using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class UnitOfWork
    {
        public UsersRepository Users { get; }
        public GamingPubsRepository GamingPubs { get; }
        public ReservationsRepository Reservations { get; }
        public AddressRepository Address { get; }
        public ScheduleRepository Schedule { get; }

        private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext,
            UsersRepository customersRepository,
            GamingPubsRepository gamingPubsRepository,
            ReservationsRepository reservationsRepository,
            AddressRepository addressRepository,
            ScheduleRepository scheduleRepository
        )
        {
            _dbContext = dbContext;
            Users = customersRepository;
            GamingPubs = gamingPubsRepository;
            Reservations = reservationsRepository;
            Address = addressRepository;
            Schedule = scheduleRepository;
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