using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class AddressRepository: RepositoryBase<Adress>
    {
        public AddressRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}