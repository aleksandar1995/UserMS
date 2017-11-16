using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMS.Models;
using UserMS.Util;
using System.Data.SqlClient;
using System.Data;

namespace UserMS.DataAccess
{
    public static class UserDB
    {
        public static UserDB GetUserById(int id)
        {
            try
            {
                User userToReturn = new User();

                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandTex = String.Format(@"
                        SELECT *
                        FROM [user].[User]
                        WHERE [id] = @id
                    ");
                    command.Parameters.Add("@id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;
                    using (SqlDataReader reader = command.ExecuteReader())

                    {
                        if (reader.Read())
                        {
                            userToReturn.Id = (int)reader["Id"];
                            userToReturn.Name = reader["Name"] as string; 
                        }

                    }
                }
                return userToReturn;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        //public static List<User> usersInMemory = new List<User>();


        //public static List<User> GetUsers
        //{
        //    return usersInMemory;
        //}

        //public static User GetUserById(int id)
        //{
        //    foreach (User user in usersInMemory)
        //    {
        //        if (user.Id == id)
        //        {
        //            return user;
        //        }
        //    }
        //    return null;
        //}

        //public static User CreateUser(User user)
        //{
        //    usersInMemory.Add(user);
        //    return GetUserById(user.Id.Value);
        //}

    }
}