using BusinessLayer.Dtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private UsersRepository userRepository;
        private AuthorizationService authorizationService { get; set; }

        public UserService(UsersRepository userRepository, AuthorizationService authorizationService)
        {
            this.userRepository = userRepository;
            this.authorizationService = authorizationService;
        }

        public List<User> GetAll()
        {
            var customers = userRepository.GetAll();
            return customers;
        }

        public bool AddUser(AddUserDto customer)
        {
            var customers = userRepository.GetAll();
            var foundUser = customers.FirstOrDefault(x => x.FirstName == customer.Name);

            if (foundUser == null)
            {
                userRepository.AddUser(new User { FirstName = customer.Name });
                return true;
            }

            return false;
        }

        public bool RemoveUserById(RemoveUserDto customer)
        {
            var foundUser = userRepository.GetUserById(customer.Id);

            if (foundUser != null)
            {
                userRepository.RemoveUser(foundUser);
                return true;
            }

            return false;
        }

        public bool UpdateUser(UpdateUserDto customer)
        {
            if (!string.IsNullOrEmpty(customer.Name))
            {
                var foundUser = userRepository.GetUserById(customer.Id);
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