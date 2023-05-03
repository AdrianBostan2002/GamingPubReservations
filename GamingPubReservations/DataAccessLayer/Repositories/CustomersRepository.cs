using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class UsersRepository: RepositoryBase<User>
    {
        public UsersRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public void AddUser(User customer)
        {
            _dbContext.Users.Add(customer);
        }

        public void RemoveUser(User customer)
        {
            _dbContext.Users.Remove(customer);
        }

        public User GetUserById(int id)
        {
            var result = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}