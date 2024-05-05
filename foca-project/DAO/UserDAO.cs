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

        public void CreateUser(User user)
        {
            string[] properties = ["name", "email", "password"];
            string[] values = [user.Name, user.Email, user.Password];

            MySqlCommand cmd = _CRUDDAO.Create("users", properties, values);

            cmd.ExecuteNonQuery();
        }

        public void UpdateUser(User user)
        {
            string[] properties = { "name", "email", "password" };
            string[] values = { user.Name, user.Email, user.Password };
            string[] where = { "idusers = " + user.Id };

            MySqlCommand cmd = _CRUDDAO.Update("users", properties, values, where);

            cmd.ExecuteNonQuery();
        }

        public void DeleteUser(User user)
        {
            string[] where = { "idusers = " + user.Id };

            MySqlCommand cmd = _CRUDDAO.Delete("users", where);

            cmd.ExecuteNonQuery();
        }
    }
}
