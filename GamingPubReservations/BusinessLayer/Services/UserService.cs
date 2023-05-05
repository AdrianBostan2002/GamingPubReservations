using BusinessLayer.Dtos;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<User> GetAll()
        {
            var customers = unitOfWork.UsersRepository.GetAll();
            return customers;
        }

        public void Register(AddUserDto customer)
        {
            var foundUser = unitOfWork.UsersRepository.GetUserByFirstNameAndLastName(customer.FirstName, customer.LastName);

            //TODO: Add authorization service


            AddAddressDto newAddresDto = customer.AddAdressDto;

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
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            DateOfBirth = customer.DateOfBirth,
                            //TODO: FIX THIS
                            PhoneNumber= customer.PhoneNumber,
                            PasswordHash = customer.Password,
                            Email= customer.Email,
                            Adress = newAdress,
                            Role = customer.Role
                        });
                unitOfWork.SaveChanges();
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