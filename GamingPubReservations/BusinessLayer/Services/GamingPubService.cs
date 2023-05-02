using BusinessLayer.Dtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class GamingPubService
    {
        private GamingPubsRepository gamingPubsRepository;
        public GamingPubService(GamingPubsRepository gamingPubsRepository)
        {
            this.gamingPubsRepository = gamingPubsRepository;
        }

        public List<GamingPub> GetAll()
        {
            return gamingPubsRepository.GetAll();
        }

        public bool AddGamingPub(AddGamingPubDto gamingPub)
        {
            var foundGamingPub = gamingPubsRepository.GetAll().FirstOrDefault(x => x.Name.Equals(gamingPub.Name));
            if(foundGamingPub != null) 
            {
                return false;
            }
            //gamingPubsRepository.AddGamingPub(new GamingPub(gamingPub.Name, gamingPub.Address));
            return true;
        }
    }
}
