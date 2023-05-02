using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class GamingPubsRepository
    {
        public List<GamingPub> GetAll()
        {
            return AppDbContext.GamingPubs;
        }

        public GamingPub GetPubByName(string name)
        {
            return AppDbContext.GamingPubs.FirstOrDefault(x => x.Name == name);
        }

        public void AddGamingPub(GamingPub pub)
        {
            AppDbContext.GamingPubs.Add(pub);
        }
    }
}