using foca_project.ViewModels;
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
        private readonly UserVM _UserVM = new UserVM();
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void botaoConfirmar_Click(object sender, RoutedEventArgs e)
        {
            loginUser();
            if (loginUser())
            {
                NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
            }
        }

        private bool loginUser()
        {
            string email = campo_Email.Text;
            string senha = campo_Senha.Text;

            if (string.IsNullOrWhiteSpace(email) || email == "E-mail")
            {
                MessageBox.Show("Por favor, insira um e-mail válido.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(senha) || senha == "Senha")
            {
                MessageBox.Show("Por favor, insira uma senha válida.");
                return false;
            }

            if (_UserVM.Login(email, senha) == null)
            {
                MessageBox.Show("E-mail ou senha inválidos.");
                return false;
            }
            MessageBox.Show("Usuário logado com sucesso.");
            return true;
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

        
    }
}
