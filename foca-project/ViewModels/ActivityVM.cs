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
    }
}
