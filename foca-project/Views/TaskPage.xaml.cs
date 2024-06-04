using foca_project.Models;
using foca_project.ViewModels;
using foca_project.Views.Templates;
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

namespace foca_project.Views
{
    /// <summary>
    /// Interação lógica para TaskPage.xam
    /// </summary>
    public partial class TaskPage : Page
    {
        ActivityVM _ActivityVM = new ActivityVM();

        public TaskPage(string nome)
        {
            InitializeComponent();
            page_titulo.Content = nome;
        }

        private void nova_task_Click(object sender, RoutedEventArgs e)
        {
            NewActivityWindow newActivityWindow = new NewActivityWindow(this);
            newActivityWindow.Show();
        }

        public void AdicionarTask(ActivityModel model)
        {
            int iduser = 1;
            List<ActivityModel> activities = _ActivityVM.GetActivitiesByUser(iduser);

            model.IsReadOnly = true;

            RowDefinition newRow = new RowDefinition();
            newRow.Height = new GridLength(120);
            task_grid.RowDefinitions.Add(newRow);

            Frame newTaskFrame = new Frame();
            newTaskFrame.HorizontalAlignment = HorizontalAlignment.Stretch;
            newTaskFrame.VerticalAlignment = VerticalAlignment.Stretch;
            newTaskFrame.Margin = new Thickness(10, 5, 0, 5);
            newTaskFrame.MinHeight = 120;

            newTaskFrame.Navigate(new Activity(model));

            task_grid.Children.Add(newTaskFrame);
            Grid.SetRow(newTaskFrame, task_grid.RowDefinitions.Count - 1);        
        }
    }
}
