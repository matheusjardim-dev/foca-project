using foca_project.Models;
using foca_project.ViewModels;
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
    /// <summary>
    /// Lógica interna para Activities.xaml
    /// </summary>
    public partial class Activities : Window
    {
        ActivityVM _ActivityVM = new ActivityVM();
        public Activities()
        {
            InitializeComponent();
            ListActivities();
        }

        private void ListActivities()
        {
            //TODO: Get user id from... (where?)
            int idDirectory = 1;
            List<ActivityModel> activities = _ActivityVM.GetActivitiesByDirectory(idDirectory);
            ActivitiesList.ItemsSource = activities;
        }
    }
}
