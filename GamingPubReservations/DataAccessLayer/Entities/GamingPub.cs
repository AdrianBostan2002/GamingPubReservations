namespace DataAccessLayer.Entities
{
    public class GamingPub
    {
        private static int _autoincrementableId = 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<GamingPlatform> GamingPlatforms { get; set; }

        public GamingPubSchedule Schedule { get; set; }

        public GamingPub(string name, string address) {
            _autoincrementableId++;
            Id = _autoincrementableId;
            Name = name;
            Address = address;
            Reservations = new List<Reservation>();
            GamingPlatforms = new List<GamingPlatform>();
            Schedule = new GamingPubSchedule();
        }
    }
}