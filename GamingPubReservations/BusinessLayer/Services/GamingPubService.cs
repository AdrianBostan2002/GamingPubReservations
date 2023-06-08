using BusinessLayer.Dtos;
using BusinessLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public class GamingPubService
    {
        private readonly UnitOfWork unitOfWork;

        public GamingPubService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<GamingPub> GetAll()
        {
            return unitOfWork.GamingPubsRepository.GetAll();
        }

        public bool AddGamingPub(AddGamingPubDto gamingPubDto)
        {
            var foundGamingPub = unitOfWork.GamingPubsRepository.GetPubByName(gamingPubDto.Name);

            if(foundGamingPub != null) 
            {
                return false;
            }

            GamingPub newGamingPub = gamingPubDto.ToGamingPub();

            unitOfWork.GamingPubsRepository.Insert(newGamingPub);

            unitOfWork.SaveChanges();

            return true;
        }
    }
}