using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public int AdressId { get; set; }
        public Adress Adress { get; set; }
    }
}