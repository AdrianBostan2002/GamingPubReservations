using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class AddUserDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}