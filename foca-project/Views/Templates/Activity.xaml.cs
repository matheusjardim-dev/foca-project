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
        public ActivityModel activityModel { get; private set; }
        public DatePicker datePicker => data;
        public Activity(ActivityModel model)
        {
            InitializeComponent();
            activityModel = model;
            DataContext = activityModel;
        }

        public ActivityModel ActivityModel => activityModel;

        private void VerificaEstado()
        {
            
            DateTime hoje = DateTime.Today;
            DateTime dataSelecionada = activityModel.Date_end;

            if(dataSelecionada < hoje)
            {
                estado_pendente.Visibility = Visibility.Hidden;
                estado_atrasado.Visibility = Visibility.Visible;
            }
            else if (dataSelecionada >= hoje)
            {
                estado_pendente.Visibility = Visibility.Visible;
                estado_atrasado.Visibility = Visibility.Hidden;
            }
        }

        private void titulo_GotFocus(object sender, RoutedEventArgs e)
        {
            string textoTitulo = titulo.Text;
            if (textoTitulo == "Insira um título")
            {
                titulo.Text = null;
            }
        }

        private void titulo_LostFocus(object sender, RoutedEventArgs e)
        {
            string textoTitulo = titulo.Text;
            if (string.IsNullOrEmpty(textoTitulo))
            {
                titulo.Text = "Insira um título";
            }

        }

        private void data_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            VerificaEstado();
        }

        private void botao_visualizar_Click(object sender, RoutedEventArgs e)
        {
            EditActivityWindow eaw = new EditActivityWindow(activityModel.Id);
            eaw.Show();
        }
    }
}
