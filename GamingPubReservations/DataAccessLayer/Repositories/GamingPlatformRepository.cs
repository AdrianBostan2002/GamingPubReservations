using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class GamingPlatformRepository : RepositoryBase<GamingPlatform>
    {
        public GamingPlatformRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}