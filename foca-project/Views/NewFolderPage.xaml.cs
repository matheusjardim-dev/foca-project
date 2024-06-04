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
    /// Interação lógica para NewFolderPage.xam
    /// </summary>
    public partial class NewFolderPage : Page
    {
        public NewFolderPage()
        {
            InitializeComponent();
        }

        private void folder_titulo_GotFocus(object sender, RoutedEventArgs e)
        {
            string texto = folder_titulo.Text;
            
            if(texto == "Insira um título")
            {
                folder_titulo.Text = null;
            }
        }

        private void folder_titulo_LostFocus(object sender, RoutedEventArgs e)
        {
            string texto = folder_titulo.Text;

            if(string.IsNullOrEmpty(texto) )
            {
                folder_titulo.Text = "Insira um título";
            }
        }
    }
}
