using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    internal class CustomersRepository
    {
        public List<Customer> GetAll()
        {
            return AppDbContext.Customers;
        }
    }
}