using BusinessLayer.Dtos;
using BusinessLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly AuthorizationService authorizationService;

        public UserService(UnitOfWork unitOfWork, AuthorizationService authorizationService)
        {
            this.unitOfWork = unitOfWork;
            this.authorizationService = authorizationService;
        }

        public List<User> GetAll()
        {
            var customers = unitOfWork.UsersRepository.GetAll();
            return customers;
        }

        public bool Register(RegisterDto registerUser)
        {
            var foundUser = unitOfWork.UsersRepository.GetUserByFirstNameAndLastName(registerUser.FirstName, registerUser.LastName);

            var passwordHash = authorizationService.HashPassword(registerUser.Password);

            registerUser.Password = passwordHash;

            if (foundUser != null)
            {
                return false;
            }

            User newUser = registerUser.ToUser();

            unitOfWork.UsersRepository.AddUser(newUser);
            unitOfWork.SaveChanges();

            return true;
        }

        public string ValidateLogin(LoginDto loginData)
        {
            var user = unitOfWork.UsersRepository.GetUserByEmail(loginData.Email);
            if (user == null)
            {
                return null;
            }

            var isPasswordOk = authorizationService.VerifyHashedPassword(user.PasswordHash, loginData.Password);
            if (isPasswordOk)
            {
                var role = user.Role;
                return authorizationService.GetToken(user, role);
            }
            else
            {
                return null;
            }
        }

        public bool RemoveUserById(RemoveUserDto customer)
        {
            var foundUser = unitOfWork.UsersRepository.GetUserById(customer.Id);

            if (foundUser != null)
            {
                unitOfWork.UsersRepository.RemoveUser(foundUser);
                return true;
            }

            return false;
        }

        public bool UpdateUser(UpdateUserDto customer)
        {
            if (!string.IsNullOrEmpty(customer.Name))
            {
                var foundUser = unitOfWork.UsersRepository.GetUserById(customer.Id);
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