using System;
using System.Collections.Generic;
using System.Linq;
using pjo_api.Models;

namespace pjo_api.Services
{
    public static class UsersService
    {
        public static List<User> Users { set; get; }

        public static List<User> GetUsers()
        {
            Users = new List<User>
            {
                new User { Id = 1, Email = "xuandt@gmail.com", Name = "Xuan Do Thanh", Password = "123456", Role = "Admin" },
                new User { Id = 2, Email = "ken@gmail.com", Name = "Ken Thoi", Password = "123456", Role = "Normal" },
                new User { Id = 3, Email = "doanh@gmail.com", Name = "Do Anh", Password = "123456", Role = "Normal" }
            };
            return Users;
        }

        public static User GetUserByCredentials(string email, string password)
        {
            var users = GetUsers();
            return users.SingleOrDefault(c => c.Email == email && c.Password == password);
        }

        public static User AddUser(User user)
        {
            Users.Add(user);
            return user;
        }
    }
}