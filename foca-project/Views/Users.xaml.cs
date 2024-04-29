using foca_project.ViewModels;
using foca_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace foca_project.Views
{
    public partial class Users : Window
    {
        UserVM _UserVM = new UserVM();
        public Users()
        {
            InitializeComponent();
            ListUsers();
        }

        private void ListUsers()
        {
            List<User> users = _UserVM.GetAllUsers();
            UsersList.ItemsSource = users;
        }
    }
}
