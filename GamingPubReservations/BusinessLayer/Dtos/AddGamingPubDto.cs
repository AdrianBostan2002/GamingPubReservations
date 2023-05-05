using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class AddGamingPubDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public AddAddressDto AddAdressDto { get; set; }

        public List<AddDayScheduleDto> Schedule { get; set; }

        public List<Reservation>? Reservations { get; set; }

        public List<AddGamingPlatformDto> GamingPlatforms { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}