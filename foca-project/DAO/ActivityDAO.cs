using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foca_project.Models;
using MySql.Data.MySqlClient;

namespace foca_project.DAO
{
    public class ActivityDAO
    {
        private static CRUDDAO _CRUDDAO = new CRUDDAO();
        public List<Activity> GetActivitiesByUser(int iduser) 
        {
            List<Activity> activities = new List<Activity>();
            MySqlCommand cmd = _CRUDDAO.GetActivitiesByUser(iduser);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    activities.Add(new Activity
                    {
                        Id = Convert.ToInt32(reader["idtasks"]),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Date_init = Convert.ToDateTime(reader["date_init"]),
                        Date_end = Convert.ToDateTime(reader["date_end"]),
                        Category = reader["category"].ToString()
                    });
                }
                return activities;
            }
        }

    }
}
