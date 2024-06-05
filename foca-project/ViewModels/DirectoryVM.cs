using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foca_project.DAO;
using foca_project.Models;

namespace foca_project.ViewModels
{
    public class DirectoryVM
    {
        private static DirectoryDAO _DirectoryDAO = new DirectoryDAO();

        public List<DirectoryModel> GetDirectoriesByUser(int iduser)
        {
            return _DirectoryDAO.GetDirectoriesByUser(iduser);
        }

        public void CreateDirectory(DirectoryModel directory)
        {
            _DirectoryDAO.CreateDirectory(directory);
        }

        public void UpdateDirectory(DirectoryModel directory)
        {
            _DirectoryDAO.UpdateDirectory(directory);
        }

        public void DeleteDirectory(int iddirectory)
        {
            _DirectoryDAO.DeleteDirectory(iddirectory);
        }

        public DirectoryModel GetDirectoryById(int iddirectory)
        {
            return _DirectoryDAO.GetDirectoryById(iddirectory);
        }
    }
}
