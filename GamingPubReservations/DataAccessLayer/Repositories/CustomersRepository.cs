using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class CustomersRepository: RepositoryBase<Customer>
    {
        public CustomersRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public void AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
        }

        public Customer GetCustomerById(int id)
        {
            var result = _dbContext.Customers.FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}