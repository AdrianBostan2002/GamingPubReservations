using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class CustomersRepository
    {
        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
            //return AppDbContext.Customers;
        }

        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
            //AppDbContext.Customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            throw new NotImplementedException();
            //AppDbContext.Customers.Remove(customer);
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
            //var result = AppDbContext.Customers.FirstOrDefault(x => x.Id == id);

            //return result;
        }
    }
}