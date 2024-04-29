using foca_project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foca_project.DAO
{
    public class UserDAO
    {
        private static CRUDDAO _CRUDDAO = new CRUDDAO();

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            MySqlCommand cmd = _CRUDDAO.SelectAll("users");

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = Convert.ToInt32(reader["idusers"]),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString()
                    });
                }
                return users;
            }
        }
    }
}
