using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agent.Interface
{
    public interface IUserAgent
    {

        void CreateUser(User user);

        User ValidateUser(string email, string password);

        User GetUserById(int id);

    }
}
