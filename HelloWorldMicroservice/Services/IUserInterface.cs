using HelloWorldMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldMicroservice.Services
{
    public interface IUserInterface
    {
        User Validate(string email, string password);
        List<User> GetUserList();
        User GetUserById(int id);
        List<User> SearchByName(string name);
    }
}
