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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace foca_project.Views.Templates
{
    /// <summary>
    /// Interação lógica para Activity.xam
    /// </summary>
    public partial class Activity : Page
    {
        private ActivityModel activityModel;
        public Activity(ActivityModel model)
        {
            InitializeComponent();
            activityModel = model;
            DataContext = activityModel;
        }

        public ActivityModel ActivityModel => activityModel;
    }
}
