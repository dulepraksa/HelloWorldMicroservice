using HelloWorldMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorldMicroservice.Services;
using System.Web;

namespace HelloWorldMicroservice.Services
{
    public class UserService : IUserInterface
    {
        private List<User> userList = new List<User>();
        public UserService()
        {
            for( var i = 1; i <= 10; i++)
            {
                userList.Add(new User
                {
                    Id = i,
                    Name = $"User {i}",
                    Password = $"pass{i}",
                    Email = $"user{i}@dummy.com",
                    Roles = new string[] {i % 2 == 0 ? "Admin" : "User" }
                });
            }
        }
        public User GetUserById(int id)
        {
            return userList.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetUserList()
        {
            return userList;
        }

        public List<User> SearchByName(string name)
        {
            return userList.Where(x => x.Name.Contains(name)).ToList();
        }

        public User Validate(string email, string password)
        {
            return userList.FirstOrDefault( x => x.Email == email && x.Password == password);
        }
    }
}