using System;
using System.Collections.Generic;
using System.Linq;
using MyApi.Models;

namespace MyApi.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly ISet<User> users = new HashSet<User>
        {
            new User(1, "username1","u1@email.com"),
            new User(2, "username2","u2@email.com"),
            new User(3, "username3", "u3@email.com"),
        };

        public User Get(string name)
        => users.First(x => x.Name == name);

        public IEnumerable<User> GetAll()
        => users;
    }
}
