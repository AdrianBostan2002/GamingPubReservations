using BusinessLayer.Dtos;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

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

        public bool Register(RegisterDto registerData)
        {
            var foundUser = unitOfWork.UsersRepository.GetUserByFirstNameAndLastName(registerData.FirstName, registerData.LastName);

            var passwordHash = authorizationService.HashPassword(registerData.Password);


            AddAddressDto newAddresDto = registerData.AddAdressDto;

            if (foundUser == null)
            {
                Adress newAdress = new Adress
                {
                    Country = newAddresDto.Country,
                    City = newAddresDto.City,
                    Street = newAddresDto.Street,
                    ZipCode = newAddresDto.ZipCode,
                    Number = newAddresDto.Number
                };

                unitOfWork.AddressRepository.Insert(newAdress);

                unitOfWork.UsersRepository.AddUser
                    (
                        new User
                        {
                            FirstName = registerData.FirstName,
                            LastName = registerData.LastName,
                            DateOfBirth = registerData.DateOfBirth,
                            //TODO: FIX THIS
                            PhoneNumber = registerData.PhoneNumber,
                            PasswordHash = passwordHash,
                            Email = registerData.Email,
                            Adress = newAdress,
                            Role = registerData.Role
                        });
                unitOfWork.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public string ValidateLogin(LoginDto loginData)
        {
            var user = unitOfWork.UsersRepository.GetUserByEmail(loginData.Email);
            if(user == null)
            {
                return null;
            }
            var isPasswordOk = authorizationService.VerifyHashedPassword(user.PasswordHash, loginData.Password);
            if(isPasswordOk)
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