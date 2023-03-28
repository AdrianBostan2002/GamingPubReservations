using BusinessLayer.Dtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class CustomerService
    {
        private CustomersRepository customersRepository;

        public CustomerService(CustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public List<Customer> GetAll()
        {
            var customers = customersRepository.GetAll();
            return customers;
        }

        public bool AddCustomer(AddCustomerDto customer)
        {
            var customers = customersRepository.GetAll();
            var foundUser = customers.FirstOrDefault(x => x.Name == customer.Name);

            if (foundUser == null)
            {
                customersRepository.AddCustomer(new Customer(customer.Name));
                return true;
            }

            return false;
        }

        public bool RemoveCustomerById(RemoveCustomerDto customer)
        {
            var foundUser = customersRepository.GetCustomerById(customer.Id);

            if (foundUser != null)
            {
                customersRepository.RemoveCustomer(foundUser);
                return true;
            }

            return false;
        }

        public bool UpdateCustomer(UpdateCustomerDto customer)
        {
            if (!string.IsNullOrEmpty(customer.Name))
            {
                var foundCustomer = customersRepository.GetCustomerById(customer.Id);
                if (foundCustomer != null)
                {
                    foundCustomer.Name = customer.Name;
                    return true;
                }
            }
            return false;
        }
    }
}