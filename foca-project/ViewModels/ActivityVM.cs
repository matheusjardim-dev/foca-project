using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foca_project.DAO;
using foca_project.Models;

namespace foca_project.ViewModels
{
    public class ActivityVM
    {
        private static ActivityDAO _ActivityDAO = new ActivityDAO();

        public List<ActivityModel> GetActivitiesByUser(int iduser)
        {
            return _ActivityDAO.GetActivitiesByUser(iduser);
        }

        public void CreateActivity(ActivityModel activity)
        {
            _ActivityDAO.CreateActivity(activity);
        }

        public void UpdateActivity(ActivityModel activity)
        {
            _ActivityDAO.UpdateActivity(activity);
        }

        public void DeleteActivity(int idActivity)
        {
            _ActivityDAO.DeleteActivity(idActivity);
        }

        public ActivityModel GetActivityById(int idActivity)
        {
            return _ActivityDAO.GetActivityById(idActivity);
        }
    }
}
