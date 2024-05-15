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
            botaoConfirmar.Click += ClickButton;
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            loginUser();
        }

        private bool loginUser()
        {
            string email = CampoEmail.Text;
            string senha = CampoSenha.Text;

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
