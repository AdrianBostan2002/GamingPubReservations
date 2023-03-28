using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class AddCustomerDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}