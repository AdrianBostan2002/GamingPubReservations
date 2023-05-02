using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class GamingPlatform : BaseEntity
    {
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<GamingPub> GamingPubs { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}