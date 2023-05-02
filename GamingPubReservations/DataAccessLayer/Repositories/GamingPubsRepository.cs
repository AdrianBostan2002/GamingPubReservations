using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class GamingPubsRepository
    {
        public List<GamingPub> GetAll()
        {
            return DbContext.GamingPubs;
        }

        public GamingPub GetPubByName(string name)
        {
            return DbContext.GamingPubs.FirstOrDefault(x => x.Name == name);
        }

        public void AddGamingPub(GamingPub pub)
        {
            DbContext.GamingPubs.Add(pub);
        }
    }
}