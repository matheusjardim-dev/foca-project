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
    /// Interação lógica para LoginPage.xam
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Botao_Cadastro_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                NavigationService.Navigate(new Uri("/Views/CreateAccount.xaml", UriKind.Relative));
            }
        }

        private void CampoEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            string textoEmail = CampoEmail.Text;
            if (textoEmail == "E-mail")
            {
                CampoEmail.Text = null;
            }
        }

        private void CampoEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            string textoEmail = CampoEmail.Text;
            if (string.IsNullOrWhiteSpace(textoEmail))
            {
                CampoEmail.Text = "E-mail";
            }
        }

        private void CampoSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            string textoSenha = CampoSenha.Text;
            if (textoSenha == "Senha")
            {
                CampoSenha.Text = null;
            }
        }

        private void CampoSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            string textoSenha = CampoSenha.Text;
            if (string.IsNullOrWhiteSpace(textoSenha))
            {
                CampoSenha.Text = "Senha";
            }
        }
    }
}
