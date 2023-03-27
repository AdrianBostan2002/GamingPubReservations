namespace DataAccessLayer.Entities
{

    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Customer(int id, string name)
        {
            Name = name;
        }
    }
}