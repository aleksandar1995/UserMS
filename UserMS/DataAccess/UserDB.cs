using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMS.Models;
using UserMS.Util;

namespace UserMS.DataAccess
{
    public static class UserDB
    {
        public static List<User> usersInMemory = new List<User>();


        public static List<User> GetUsers
        {
            return usersInMemory;
        }

        public static User GetUserById(int id)
        {
            foreach (User user in usersInMemory)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public static User CreateUser(User user)
        {
            usersInMemory.Add(user);
            return GetUserById(user.Id.Value);
        }
    }
}