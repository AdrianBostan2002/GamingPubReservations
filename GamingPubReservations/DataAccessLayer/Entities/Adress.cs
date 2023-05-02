namespace DataAccessLayer.Entities
{
    public class Adress : BaseEntity
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int ZipCode { get; set; }

        public int Number { get; set; }
    }
}