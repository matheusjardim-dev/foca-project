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
        public List<ActivityModel> GetActivitiesByUser(int iduser) 
        {
            List<ActivityModel> activities = new List<ActivityModel>();
            MySqlCommand cmd = _CRUDDAO.GetActivitiesByUser(iduser);

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
                        Category = reader["category"].ToString()
                    });
                }
                return activities;
            }
        }

        public void CreateActivity(ActivityModel activity)
        {
            string[] properties = { 
                "title", 
                "description", 
                "date_init", 
                "date_end", 
                "category_idcategory", 
                "users_idusers" 
            };
            string[] values = { 
                activity.Title, 
                activity.Description, 
                activity.Date_init.ToString("yyyy-MM-dd"), 
                activity.Date_end.ToString("yyyy-MM-dd"), 
                "1", 
                activity.Id_user.ToString()
            };
           
            MySqlCommand cmd = _CRUDDAO.Create("tasks", properties, values);
            cmd.ExecuteNonQuery();
        }

        public ActivityModel GetActivityById(int idActivity)
        {
            string[] where = { "idtasks = " + idActivity.ToString() };
            MySqlCommand cmd = _CRUDDAO.SelectById("tasks", where);

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
                    };
                }
                return null;
            }
        }

        public void UpdateActivity(ActivityModel activity)
        {
            string[] properties = { "title", "description", "date_end" };
            string[] values = { activity.Title, activity.Description, activity.Date_end.ToString() };
            string[] where = { "users_idusers = " + activity.Id_user.ToString() };
            MySqlCommand cmd = _CRUDDAO.Update("tasks", properties, values, where);
        }

        public void DeleteActivity(int idActivity)
        {
            string[] where = { "idtasks = " + idActivity.ToString() };
            MySqlCommand cmd = _CRUDDAO.Delete("tasks", where);
        }
    }
}
