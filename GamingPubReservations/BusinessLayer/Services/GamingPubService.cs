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
            return unitOfWork.GamingPubs.GetAll();
        }

        public bool AddGamingPub(AddGamingPubDto gamingPubDto)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetPubByName(gamingPubDto.Name);

            if(foundGamingPub != null) 
            {
                return false;
            }

            GamingPub newGamingPub = gamingPubDto.ToGamingPub();

            unitOfWork.GamingPubs.Insert(newGamingPub);

            unitOfWork.SaveChanges();

            return true;
        }
    }
}