using BusinessLayer.Dtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private UsersRepository customersRepository;

        public UserService(UsersRepository customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public List<User> GetAll()
        {
            var customers = customersRepository.GetAll();
            return customers;
        }

        public bool AddUser(AddUserDto customer)
        {
            var customers = customersRepository.GetAll();
            var foundUser = customers.FirstOrDefault(x => x.FirstName == customer.Name);

            if (foundUser == null)
            {
                customersRepository.AddUser(new User { FirstName = customer.Name });
                return true;
            }

            return false;
        }

        public bool RemoveUserById(RemoveUserDto customer)
        {
            var foundUser = customersRepository.GetUserById(customer.Id);

            if (foundUser != null)
            {
                customersRepository.RemoveUser(foundUser);
                return true;
            }

            return false;
        }

        public bool UpdateUser(UpdateUserDto customer)
        {
            if (!string.IsNullOrEmpty(customer.Name))
            {
                var foundUser = customersRepository.GetUserById(customer.Id);
                if (foundUser != null)
                {
                    foundUser.FirstName = customer.Name;
                    return true;
                }
            }
            return false;
        }
    }
}