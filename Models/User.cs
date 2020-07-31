using System.Collections.Generic;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace To_Do_List.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        // constructor
        public User(int id, string userName, string password)
        {
            UserId = id;
            UserName = userName;
            Password = password;
        }

        public User()
        {
            
        }
    }

    // user manager class to store list of users
    public class UserManager
    {
        public static List<User> users = new List<User>
        {
            new User(1, "himanshu", "him")
        };
    }
}