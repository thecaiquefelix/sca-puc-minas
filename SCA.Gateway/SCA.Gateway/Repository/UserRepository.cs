using System;
using System.Collections.Generic;
using System.Linq;
using SCA.Gateway.Domain;

namespace SCA.Gateway.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new User { Id = 1, Username = "caique", Password = "123456", Role = "admin" },
                new User { Id = 1, Username = "maria", Password = "123456", Role = "maintenance" }
            };
            return users.Where(x => string.Equals(x.Username, username, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(password)).FirstOrDefault();
        }
    }
}
