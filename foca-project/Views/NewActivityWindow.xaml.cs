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
using System.Windows.Shapes;

namespace foca_project.Views
{
    /// <summary>
    /// Lógica interna para NewActivityWindow.xaml
    /// </summary>
    public partial class NewActivityWindow : Window
    {
        ActivityVM _ActivityVM = new ActivityVM();
        private TaskPage taskpage;
        private Activity activity;
        public NewActivityWindow(TaskPage taskpage)
        {
            InitializeComponent();
            this.taskpage = taskpage;
            var model = new ActivityModel { Title = "Insira um título" , Date_end = DateTime.Now};
            activity = new Activity(model);
            frame_activity.Navigate(activity);
            activity.botao_visualizar.Visibility = Visibility.Hidden;
            
        }

        private void descricao_GotFocus(object sender, RoutedEventArgs e)
        {
            string textoDescricao = descricao.Text;
            if (textoDescricao == "Insira uma descrição")
            {
                descricao.Text = null;
            }
        }

        private void descricao_LostFocus(object sender, RoutedEventArgs e)
        {
            string textoDescricao = descricao.Text;
            if (string.IsNullOrEmpty(textoDescricao))
            {
                descricao.Text = "Insira uma descrição";
            }

        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmar_Click(object sender, RoutedEventArgs e)
        {
            var model = activity.ActivityModel;
            model.Description = descricao.Text;
            model.Date_end = (DateTime)activity.datePicker.SelectedDate;
            model.Directory = 4;
            model.Id_user = 1;
            _ActivityVM.CreateActivity(model);
            List<ActivityModel> tasks = _ActivityVM.GetActivitiesByDirectory(model.Directory);
            foreach (ActivityModel task in tasks)
            {
                taskpage.AdicionarTask(task);
            }
            this.Close();
        }
    }
}
