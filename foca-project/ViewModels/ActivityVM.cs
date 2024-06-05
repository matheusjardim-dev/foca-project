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

        public List<ActivityModel> GetActivitiesByDirectory(int idDirectory)
        {
            return _ActivityDAO.GetActivitiesByDirectory(idDirectory);
        }

        public void CreateActivity(ActivityModel activity)
        {
            _ActivityDAO.CreateActivity(activity, 1);
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
