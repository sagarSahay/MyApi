using System;
using System.Collections.Generic;
using MyApi.Models;

namespace MyApi.Repositories
{
    public interface IUserRepository
    {
        User Get(string name);

        IEnumerable<User> GetAll();
    }
}
