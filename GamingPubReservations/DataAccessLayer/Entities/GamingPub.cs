namespace DataAccessLayer.Entities
{
    public class GamingPub
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<GamingPlatform> GamingPlatforms { get; set; }

        public GamingPubSchedule Schedule { get; set; }

        public GamingPub() { }
    }
}