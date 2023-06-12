namespace BusinessLayer.Dtos
{
    public class AvailableReservation
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string GamingPubName { get; set; }

        public List<string> AvailableGamingPlatformsName { get; set; }
    }
}