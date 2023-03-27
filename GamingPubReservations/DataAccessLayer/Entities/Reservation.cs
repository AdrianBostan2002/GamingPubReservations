using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public Customer Customer { get; private set; }

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        GamingPlatformType GamingPlatformType { get; set; }

        public Reservation(int id, Customer customer, DateTime startDate, DateTime endDate, GamingPlatformType gamingPlatformType)
        {
            Id = id;
            Customer = customer;
            StartDate = startDate;
            EndDate = endDate;
            GamingPlatformType = gamingPlatformType;
        }
    }
}