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
using foca_project.Models;
using foca_project.ViewModels;

namespace foca_project.Views
{
    /// <summary>
    /// Interação lógica para CreateAccount.xam
    /// </summary>
    public partial class CreateAccount : Page
    {
        private readonly UserVM _UserVM = new UserVM();
        public CreateAccount()
        {
            InitializeComponent();
            botaoConfirmar.Click += ClickButton;
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            createUser();
        }

        private void Faca_login_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null)
            {
                NavigationService.Navigate(new Uri("/Views/LoginPage.xaml", UriKind.Relative));
            }
        }

        private void CampoNome_GotFocus(object sender, RoutedEventArgs e)
        {
            string textoNome = CampoNome.Text;
            if (textoNome == "Nome")
            {
                CampoNome.Text = null;
            }
        }

        private void CampoNome_LostFocus(object sender, RoutedEventArgs e)
        {
            string textoNome = CampoNome.Text;
            if (string.IsNullOrWhiteSpace(textoNome))
            {
                CampoNome.Text = "Nome";
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

        private bool createUser()
        {
            if (
                string.IsNullOrWhiteSpace(CampoNome.Text) ||
                string.IsNullOrWhiteSpace(CampoEmail.Text) ||
                string.IsNullOrWhiteSpace(CampoSenha.Text)
                )
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }

            User _user = new()
            {
                Name = CampoNome.Text,
                Email = CampoEmail.Text,
                Password = CampoSenha.Text
            };
            _UserVM.CreateUser(_user);
            return true;
        }
    }
}
