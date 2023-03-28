namespace DataAccessLayer.Entities
{
    public class Customer
    {
        private static int _autoincrementableId = 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public Customer(string name)
        {
            _autoincrementableId++;
            Id = _autoincrementableId;
            Name = name;
        }
    }
}