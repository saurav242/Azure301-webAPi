using Entity;
using Entity.Models;
using Repository.Interface;
using System.Linq;

namespace Repository
{

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public User GetUserById(int id)
        {
            return FindByCondition(usr => usr.Id == id).FirstOrDefault();
        }

        public User ValidateUser(string email, string password)
        {
            return FindByCondition(usr => usr.Email == email && usr.Password == password).FirstOrDefault();
        }
    }
}
