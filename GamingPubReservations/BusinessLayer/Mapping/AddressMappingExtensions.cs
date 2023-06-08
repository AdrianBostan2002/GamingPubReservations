using BusinessLayer.Dtos;
using DataAccessLayer.Entities;

namespace BusinessLayer.Mapping
{
    public static class AddressMappingExtensions
    {
        public static Adress ToAddress(this AddAddressDto addressDto)
        {
            Adress address = new Adress
            {
                Country = addressDto.Country,
                City = addressDto.City,
                Street = addressDto.Street,
                ZipCode = addressDto.ZipCode,
                Number = addressDto.Number
            };

            return address;
        }
    }
}