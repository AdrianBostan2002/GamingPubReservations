using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class CustomersRepository
    {
        public List<Customer> GetAll()
        {
            return AppDbContext.Customers;
        }

        public void AddCustomer(Customer customer)
        {
            AppDbContext.Customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            AppDbContext.Customers.Remove(customer);
        }

        public Customer GetCustomerById(int id)
        {
            var result = AppDbContext.Customers.FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}