using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class GamingPlatformRepository : RepositoryBase<GamingPlatform>
    {
        public GamingPlatformRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public List<GamingPlatform> GetByGamingPub(GamingPub gamingPub)
        {
            var foundGamingPub = _dbContext.GamingPubs
                .Where(gb => gb.Id == gamingPub.Id)
                .Include(platform => platform.GamingPlatforms)
                .FirstOrDefault();

            return foundGamingPub.GamingPlatforms.ToList();
        }
    }
}