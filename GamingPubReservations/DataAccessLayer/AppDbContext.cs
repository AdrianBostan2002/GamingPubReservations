using DataAccessLayer.Entities;
using DataAccessLayer.Enums;

namespace DataAccessLayer
{
    public static class AppDbContext
    {
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer("Sebi"),
            new Customer("Adi"),
            new Customer("Andrei"),
            new Customer("Mircea"),
            new Customer("Ionut"),
            new Customer("Cristian"),
            new Customer("George"),
            new Customer("Adelin"),
            new Customer("Marius"),
            new Customer( "Alex")
        };

        public static List<GamingPub> GamingPubs = new List<GamingPub>();
    }
}