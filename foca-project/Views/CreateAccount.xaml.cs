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
            botao_Confirmar.Click += ClickButton;
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            if (createUser())
            {
                NavigationService.Navigate(new Uri("/Views/LoginPage.xaml", UriKind.Relative));
            }

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
            string textoNome = campo_Nome.Text;
            if (textoNome == "Nome")
            {
                campo_Nome.Text = null;
            }
        }

        private void CampoNome_LostFocus(object sender, RoutedEventArgs e)
        {
            string textoNome = campo_Nome.Text;
            if (string.IsNullOrWhiteSpace(textoNome))
            {
                campo_Nome.Text = "Nome";
            }
        }

        private void CampoEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            string textoEmail = campo_Email.Text;
            if (textoEmail == "E-mail")
            {
                campo_Email.Text = null;
            }
        }

        private void CampoEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            string textoEmail = campo_Email.Text;
            if (string.IsNullOrWhiteSpace(textoEmail))
            {
                campo_Email.Text = "E-mail";
            }
        }

        private void CampoSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            string textoSenha = campo_Senha.Text;
            if (textoSenha == "Senha")
            {
                campo_Senha.Text = null;
            }
        }

        private void CampoSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            string textoSenha = campo_Senha.Text;
            if (string.IsNullOrWhiteSpace(textoSenha))
            {
                campo_Senha.Text = "Senha";
            }
        }

        private bool createUser()
        {
            if (
                string.IsNullOrWhiteSpace(campo_Nome.Text) ||
                string.IsNullOrWhiteSpace(campo_Email.Text) ||
                string.IsNullOrWhiteSpace(campo_Senha.Text)
                )
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }

            User _user = new()
            {
                Name = campo_Nome.Text,
                Email = campo_Email.Text,
                Password = campo_Senha.Text
            };
            _UserVM.CreateUser(_user);
            return true;
        }
    }
}
