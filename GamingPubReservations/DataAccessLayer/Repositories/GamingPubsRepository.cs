using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class GamingPubsRepository
    {
        public List<GamingPub> GetAll()
        {
            throw new NotImplementedException();
            //return AppDbContext.GamingPubs;
        }

        public GamingPub GetPubByName(string name)
        {
            throw new NotImplementedException();
            //return AppDbContext.GamingPubs.FirstOrDefault(x => x.Name == name);
        }

        public void AddGamingPub(GamingPub pub)
        {
            throw new NotImplementedException();
            //AppDbContext.GamingPubs.Add(pub);
        }
    }
}