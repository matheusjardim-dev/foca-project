using foca_project.Models;
using foca_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
    /// Interação lógica para NewFolderPage.xam
    /// </summary>
    public partial class NewFolderPage : Page
    {
        DirectoryVM _DirectoryVM = new DirectoryVM();
        public event EventHandler<string> NewFolderCreated;
        public event EventHandler Cancel;

        public NewFolderPage()
        {
            InitializeComponent();

        }

        private void folder_titulo_GotFocus(object sender, RoutedEventArgs e)
        {
            string texto = folder_titulo.Text;

            if (texto == "Insira um título")
            {
                folder_titulo.Text = null;
            }
        }

        private void folder_titulo_LostFocus(object sender, RoutedEventArgs e)
        {
            string texto = folder_titulo.Text;

            if (string.IsNullOrEmpty(texto))
            {
                folder_titulo.Text = "Insira um título";
            }
        }

        private void confirmar_Click(object sender, RoutedEventArgs e)
        {
            DirectoryModel model = new DirectoryModel();
            model.Title = folder_titulo.Text;
            model.Id_user = 1;
            _DirectoryVM.CreateDirectory(model);
            int idDirectory = model.Id;
            string folderTitle = folder_titulo.Text;
            NewFolderCreated?.Invoke(this, folderTitle);
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            Cancel?.Invoke(this, EventArgs.Empty);
        }
    }
}