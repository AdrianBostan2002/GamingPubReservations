using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dtos
{
    public class RegisterDto
    {
        [Required, MaxLength(50)]
        public string FirstName;

        [Required, MaxLength(50)]
        public string LastName;

        [Required, MaxLength(50)]
        public string Email;

        [Required, MaxLength(50)]
        public string Password;

        [Required]
        public DateTime DateOfBirth;

        [Required]
        public string PhoneNumber;
    }
}
