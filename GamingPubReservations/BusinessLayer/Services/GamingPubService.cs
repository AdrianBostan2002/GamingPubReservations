using BusinessLayer.Dtos;
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

        public bool AddGamingPub(AddGamingPubDto gamingPub)
        {
            var foundGamingPub = unitOfWork.GamingPubsRepository.GetPubByName(gamingPub.Name);

            if(foundGamingPub != null) 
            {
                return false;
            }

            AddAddressDto newAddresDto = gamingPub.AddAdressDto;

            Adress newAdress = new Adress
            {
                Country = newAddresDto.Country,
                City = newAddresDto.City,
                Street = newAddresDto.Street,
                ZipCode = newAddresDto.ZipCode,
                Number = newAddresDto.Number
            };

            unitOfWork.AddressRepository.Insert(newAdress);


            //TODO: Use mappers to map dtos

            //TODO: To finish this you have to create next mapper: MapGamingPlatformDtosToGamingPlatforms

            //Gaming

            //GamingPub newGamingPub = new GamingPub
            //{
            //    Name = gamingPub.Name,
            //    //PhoneNumber = gamingPub
            //};

            //unitOfWork.GamingPubsRepository.Insert(newGamingPub);
            return true;
        }
    }
}
