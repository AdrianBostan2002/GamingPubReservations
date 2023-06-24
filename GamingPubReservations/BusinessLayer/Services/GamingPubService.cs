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

            if (foundGamingPub != null)
            {
                return false;
            }

            GamingPub newGamingPub = gamingPubDto.ToGamingPub();

            unitOfWork.GamingPubs.Insert(newGamingPub);

            unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdateGamingPub(int gamingPubId, UpdateGamingPubDto gamingPubDto)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetById(gamingPubId);

            if (foundGamingPub == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(gamingPubDto.Name))
            {
                foundGamingPub.Name = gamingPubDto.Name;
            }

            if (gamingPubDto.AddAdressDto != null)
            {
                foundGamingPub.Adress = gamingPubDto.AddAdressDto.ToAddress();
            }

            if (!string.IsNullOrEmpty(gamingPubDto.PhoneNumber))
            {
                foundGamingPub.PhoneNumber = gamingPubDto.PhoneNumber;
            }

            unitOfWork.SaveChanges();

            return true;
        }
    }
}