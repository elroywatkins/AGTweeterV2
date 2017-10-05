using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace AG.TweeterApp
{
    public interface IUserRepository
    {
        IList<User> GetAllUsers();
        User GetByName(string name);
    }
}