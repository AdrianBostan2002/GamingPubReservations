using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}