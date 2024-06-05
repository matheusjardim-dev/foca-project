using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foca_project.Models;
using MySql.Data.MySqlClient;

namespace foca_project.DAO
{
    public class DirectoryDAO
    {
        private static CRUDDAO _CRUDDAO = new CRUDDAO();

        public List<DirectoryModel> GetDirectoriesByUser(int iduser)
        {
            List<DirectoryModel> directories = new List<DirectoryModel>();
            MySqlCommand cmd = _CRUDDAO.GetDirectoriesByUser(iduser);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    directories.Add(new DirectoryModel
                    {
                        Id = Convert.ToInt32(reader["iddirectory"]),
                        Title = reader["title"].ToString(),
                        Id_user = Convert.ToInt32(reader["users_idusers"])
                    });
                }
                return directories;
            }
        }

        public void CreateDirectory(DirectoryModel directory)
        {
            string[] properties = { "title", "users_idusers" };
            string[] values = { directory.Title, directory.Id_user.ToString() };

            MySqlCommand cmd = _CRUDDAO.Create("directory", properties, values);
            cmd.ExecuteNonQuery();
        }

        public void UpdateDirectory(DirectoryModel directory)
        {
            string[] properties = { "title" };
            string[] values = { directory.Title };

            string[] where = { "iddirectory = " + directory.Id };

            MySqlCommand cmd = _CRUDDAO.Update("directory", properties, values, where);
            cmd.ExecuteNonQuery();
        }

        public void DeleteDirectory(int iddirectory)
        {
            string[] where = { "iddirectory = " + iddirectory };

            MySqlCommand cmd = _CRUDDAO.Delete("directory", where);
            cmd.ExecuteNonQuery();
        }

        public DirectoryModel GetDirectoryById(int iddirectory)
        {
            string[] where = { "iddirectory = " + iddirectory.ToString() };
            MySqlCommand cmd = _CRUDDAO.SelectById("directory", where);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                return new DirectoryModel
                {
                    Id = Convert.ToInt32(reader["iddirectory"]),
                    Title = reader["title"].ToString(),
                    Id_user = Convert.ToInt32(reader["users_idusers"])
                };
            }
        }
    }
}
