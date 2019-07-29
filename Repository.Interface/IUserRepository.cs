using Entity.Models;

namespace Repository.Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        void CreateUser(User user);

        User ValidateUser(string email, string password);

        User GetUserById(int id);

    }

}
