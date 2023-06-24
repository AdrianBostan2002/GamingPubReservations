using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dtos
{
    public class UpdateGamingPubDto
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }

        public AddAddressDto? AddAdressDto { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }
}
