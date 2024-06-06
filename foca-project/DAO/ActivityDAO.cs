using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foca_project.Models;
using foca_project.Views;
using MySql.Data.MySqlClient;

namespace foca_project.DAO
{
    public class ActivityDAO
    {
        private static CRUDDAO _CRUDDAO = new CRUDDAO();
        public List<ActivityModel> GetActivitiesByDirectory(int idDirectory) 
        {
            List<ActivityModel> activities = new List<ActivityModel>();
            MySqlCommand cmd = _CRUDDAO.GetActivitiesByDirectory(idDirectory);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    activities.Add(new ActivityModel
                    {
                        Id = Convert.ToInt32(reader["idtasks"]),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Date_init = Convert.ToDateTime(reader["date_init"]),
                        Date_end = Convert.ToDateTime(reader["date_end"]),
                        isConcluded = Convert.ToBoolean(reader["is_concluded"]),
                    });
                }
                return activities;
            }
        }

        public void CreateActivity(ActivityModel activity, int idDirectory)
        {
            idDirectory = 4;
            activity.Directory = idDirectory;
            string[] properties = { 
                "title", 
                "description", 
                "date_init", 
                "date_end", 
                "is_concluded",
                "directory_iddirectory",
                "users_idusers" 
            };
            string[] values = { 
                activity.Title, 
                activity.Description, 
                activity.Date_init.ToString("yyyy-MM-dd"), 
                activity.Date_end.ToString("yyyy-MM-dd"),
                "1",
                activity.Directory.ToString(), 
                activity.Id_user.ToString()
            };
           
            MySqlCommand cmd = _CRUDDAO.Create("tasks", properties, values);
            cmd.ExecuteNonQuery();
        }

        public ActivityModel GetActivityById(int idActivity)
        {
            MySqlCommand cmd = _CRUDDAO.GetActivityById(idActivity);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new ActivityModel
                    {
                        Id = Convert.ToInt32(reader["idtasks"]),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Date_end = Convert.ToDateTime(reader["date_end"]),
                        isConcluded = Convert.ToBoolean(reader["is_concluded"]),
                    };
                }
                return null;
            }
        }

        public void UpdateActivity(ActivityModel activity)
        {
            string[] properties = { "title", "description", "date_end", "is_concluded" };
            string[] values = { activity.Title, activity.Description, activity.Date_end.ToString(), "1"};
            string[] where = { "idtasks = " + activity.Id.ToString() };
            MySqlCommand cmd = _CRUDDAO.Update("tasks", properties, values, where);
        }

        public void DeleteActivity(int idActivity)
        {
            string[] where = { "idtasks = " + idActivity.ToString() };
            MySqlCommand cmd = _CRUDDAO.Delete("tasks", where);
        }
    }
}
