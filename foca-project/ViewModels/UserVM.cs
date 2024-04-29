using foca_project.DAO;
using foca_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foca_project.ViewModels
{
    public class UserVM
    {
        private static UserDAO _UserDAO = new UserDAO();

        public List<User> GetAllUsers()
        {
            return _UserDAO.GetAllUsers();
        }
    }
}
