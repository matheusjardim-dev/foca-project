using foca_project.Models;
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
        private TaskPage taskpage;
        private Activity activity;
        public NewActivityWindow()
        {
            InitializeComponent();
            activity = new Activity(new ActivityModel { Title = "Insira um título" });
            frame_activity.Navigate(activity);
            taskpage = new TaskPage("teste");
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
            taskpage.AdicionarTask(model);
            this.Close();
        }
    }
}
