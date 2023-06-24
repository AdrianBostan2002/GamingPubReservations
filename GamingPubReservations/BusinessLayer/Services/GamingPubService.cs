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
            var gamingPubs = unitOfWork.GamingPubs.GetAll();
            foreach (var pub in gamingPubs)
            {
                pub.Address = unitOfWork.Address.GetById(pub.AddressId);
            }
            return gamingPubs;
        }

        public Address GetAddress(int id) 
        { 
            var pub = unitOfWork.GamingPubs.GetById(id);
            return unitOfWork.Address.GetById(pub.AddressId);
        }

        public bool AddGamingPub(AddGamingPubDto gamingPubDto)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetPubByName(gamingPubDto.Name);

            if (foundGamingPub != null)
            {
                return false;
            }

            GamingPub newGamingPub = gamingPubDto.ToGamingPub();

            if (newGamingPub.Address != null)
            {
                unitOfWork.Address.Insert(newGamingPub.Address);
            }

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
                foundGamingPub.Address = gamingPubDto.AddAdressDto.ToAddress();
            }

            if (!string.IsNullOrEmpty(gamingPubDto.PhoneNumber))
            {
                foundGamingPub.PhoneNumber = gamingPubDto.PhoneNumber;
            }

            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteGamingPub(int gamingPubId)
        {
            var foundGamingPub = unitOfWork.GamingPubs.GetById(gamingPubId);

            if (foundGamingPub == null)
            {
                return false;
            }

            if (foundGamingPub.AddressId.HasValue)
            {
                foundGamingPub.Address = unitOfWork.Address.GetById(foundGamingPub.AddressId.Value);
                unitOfWork.Address.Remove(foundGamingPub.Address);
            }

            foundGamingPub.Reservations = unitOfWork.Reservations.GetAllReservations(foundGamingPub);

            unitOfWork.GamingPubs.Remove(foundGamingPub);

            unitOfWork.SaveChanges();

            return true;
        }
    }
}