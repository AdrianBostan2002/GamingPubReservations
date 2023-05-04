using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class GamingPub : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        public int AdressId { get; set; }
        public Adress Adress { get; set; }

        public virtual ICollection<DaySchedule> Schedule { get; set; }

        public List<Reservation> Reservations { get; set; }

        public virtual ICollection<GamingPlatform> GamingPlatforms { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}