using Agent.Interface;
using Entity.Models;
using Repository.Interface;

namespace Agent
{
    public class UserAgent : IUserAgent
    {
        private readonly IRepositoryWrapper _repository;

        public UserAgent(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public void CreateUser(User user)
        {
            _repository.User.CreateUser(user);
            _repository.Save();
        }

        public User GetUserById(int id)
        {
            return _repository.User.GetUserById(id);
        }

        public User ValidateUser(string email, string password)
        {
            return _repository.User.ValidateUser(email, password);
        }
    }
}
